using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace House
{
    /// <summary>
    /// Частичный класс формы с таблицей квартир
    /// </summary>
    public partial class FlatForm : Form
    {
        private AppContext db;
        private bool IsSearching = false;
        private bool IsFiltering = false;

        private List<Flat> changedFlats;

        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public FlatForm()
        {
            InitializeComponent();
            db = new AppContext();
            changedFlats = new List<Flat>();
            search.Hide();
            HideFilterFields();
            dataGridView1.Rows[0].Cells[0].Value = 1;
            Load_Click(null, null);
        }

        /// <summary>
        /// Обработка нажатия по пункту меню для перехода к форме жильцов
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void GoToTenants_Click(object sender, EventArgs e)
        {
            Form tanantsForm = Application.OpenForms[1];
            tanantsForm.Show();
            Hide();
        }

        /// <summary>
        /// Обработка нажатия по пункту меню для создания новой строки
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Add_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            FixLastRowId();
        }

        /// <summary>
        /// Обработка нажатия по пункту меню для открытия или сокрытия строки поиска
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Find_Click(object sender, EventArgs e)
        {
            IsSearching = !IsSearching;
            IsFiltering = false;
            if (IsSearching)
            {
                HideFilterFields();
                search.Show();
                search.Focus();
                search.Clear();
                dataGridView1.Location = new Point(dataGridView1.Location.X, 43);
                SaveValues();
            }
            else
            {
                search.Hide();
                dataGridView1.Location = new Point(dataGridView1.Location.X, 23);
                RestoreValues();
            }
        }

        /// <summary>
        /// Обработка нажатия по пункту меню для сохранения данных в БД
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Save_Click(object sender, EventArgs e)
        {
            if (IsFiltering || IsSearching)
            {
                value.Clear();
                search.Clear();
                search.Hide();
                HideFilterFields();
                dataGridView1.Location = new Point(dataGridView1.Location.X, 23);
                RestoreValues();
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index + 1 != dataGridView1.Rows.Count)
                    SaveFromGrid(row);
            }
            foreach (Flat flat in db.Flats)
            {
                if (checkToDelete(flat))
                {
                    db.Flats.Remove(flat);
                }
            }
            db.SaveChanges();
            Load_Click(null, null);
        }

        /// <summary>
        /// Обработка нажатия по пункту меню для загрузки данных из БД
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Load_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Flat flat in db.Flats)
            {
                AddToGrid(flat);
            }
            changedFlats = new List<Flat>(db.Flats.AsEnumerable());
            search.Hide();
            dataGridView1.Location = new Point(dataGridView1.Location.X, 23);
            HideFilterFields();
            FixLastRowId();
        }

        private void HideFilterFields()
        {
            value.Hide();
            field.Hide();
            biggerOrLower.Hide();
        }

        /// <summary>
        /// Обработка нажатия по пункту меню для открытия компонентов, позволяющих осуществлять сортировку
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Filter_Click(object sender, EventArgs e)
        {
            IsFiltering = !IsFiltering;
            IsSearching = false;
            if (IsFiltering)
            {
                value.Clear();
                search.Hide();
                ShowFilterFields();
                dataGridView1.Location = new Point(dataGridView1.Location.X, 23);
                SaveValues();
            }
            else
            {
                search.Hide();
                HideFilterFields();
                dataGridView1.Location = new Point(dataGridView1.Location.X, 23);
                RestoreValues();
            }
        }

        private void ShowFilterFields()
        {
            value.Show();
            biggerOrLower.Show();
            field.Show();
        }


        private void FixLastRowId()
        {
            int max = 0;
            if (dataGridView1.Rows.Count < changedFlats.Count)
            {

                foreach (Flat flat in changedFlats)
                {
                    if (max < flat.flatId)
                    {
                        max = flat.flatId;
                    }
                }

            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index != dataGridView1.Rows.Count -1)
                        if (max < int.Parse(row.Cells[0].Value.ToString()))
                        {
                            max = int.Parse(row.Cells[0].Value.ToString());
                        }
                }
            }
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = max + 1;
        }
        private void SaveValues()
        {
            changedFlats.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index + 1 != dataGridView1.Rows.Count)
                    if (row.Cells[0].Value != null)
                    {
                        changedFlats.Add(
                           new Flat(int.Parse(row.Cells[0].Value.ToString().Replace(".", ",")),
                           int.Parse(row.Cells[1].Value.ToString().Replace(".", ",")),
                              decimal.Parse(row.Cells[2].Value.ToString().Replace(".", ",")),
                              decimal.Parse(row.Cells[3].Value.ToString().Replace(".", ",")),
                              decimal.Parse(row.Cells[4].Value.ToString().Replace(".", ",")),
                              decimal.Parse(row.Cells[5].Value.ToString().Replace(".", ",")),
                              decimal.Parse(row.Cells[6].Value.ToString().Replace(".", ","))
                          )
                     );
                    }
                    else
                    {
                        changedFlats.Add(new Flat(int.Parse(row.Cells[1].Value.ToString().Replace(".", ",")),
                              decimal.Parse(row.Cells[2].Value.ToString().Replace(".", ",")),
                              decimal.Parse(row.Cells[3].Value.ToString().Replace(".", ",")),
                              decimal.Parse(row.Cells[4].Value.ToString().Replace(".", ",")),
                              decimal.Parse(row.Cells[5].Value.ToString().Replace(".", ",")),
                              decimal.Parse(row.Cells[6].Value.ToString().Replace(".", ","))
                          )
                      );
                    }
            }
        }

        private bool checkToDelete(Flat flat)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index + 1 != dataGridView1.Rows.Count)
                {
                    if (row.Cells[0].Value.ToString().Equals(flat.flatId.ToString()))
                    {
                        return false;
                    }

                }

            }
            return true;
        }

        private void RestoreValues()
        {
            dataGridView1.Rows.Clear();
            foreach (Flat flat in changedFlats)
            {
                AddToGrid(flat);
            }
            changedFlats.Clear();
            FixLastRowId();
        }

        private void AddToGrid(Flat flat)
        {
            dataGridView1.Rows.Add(flat.flatId, flat.flat_num, flat.rent, flat.energy, flat.cold_water, flat.hot_water, flat.gas);
        }
        private void SaveFromGrid(DataGridViewRow row)
        {
            var id = int.Parse(row.Cells[0].Value.ToString().Replace(".", ","));
            if (db.Flats.Find(id) != null)
            {
                db.Flats.Find(id).flat_num = int.Parse(row.Cells[1].Value.ToString().Replace(".", ","));
                db.Flats.Find(id).rent = decimal.Parse(row.Cells[2].Value.ToString().Replace(".", ","));
                db.Flats.Find(id).energy = decimal.Parse(row.Cells[3].Value.ToString().Replace(".", ","));
                db.Flats.Find(id).cold_water = decimal.Parse(row.Cells[4].Value.ToString().Replace(".", ","));
                db.Flats.Find(id).hot_water = decimal.Parse(row.Cells[5].Value.ToString().Replace(".", ","));
                db.Flats.Find(id).gas = decimal.Parse(row.Cells[6].Value.ToString().Replace(".", ","));
            }
            else
            {
                db.Flats.Add(new Flat(id, int.Parse(row.Cells[1].Value.ToString().Replace(".", ",")),
                    decimal.Parse(row.Cells[2].Value.ToString().Replace(".", ",")),
                      decimal.Parse(row.Cells[3].Value.ToString().Replace(".", ",")),
                      decimal.Parse(row.Cells[4].Value.ToString().Replace(".", ",")),
                      decimal.Parse(row.Cells[5].Value.ToString().Replace(".", ",")),
                      decimal.Parse(row.Cells[6].Value.ToString().Replace(".", ","))
                  )
              );
            }
        }

        /// <summary>
        /// Валидация данных при попытке выйти из редактирования ячейки
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex + 1 != dataGridView1.RowCount)
            {
                string headerText =
                    dataGridView1.Columns[e.ColumnIndex].HeaderText;
                string regexForInt = "^\\d{1,10}$";
                string regexForDouble = "^\\d{1,10}(|[\\,\\.]\\d+)$";
                if (headerText.Equals("Номер"))
                {
                    if (!Regex.IsMatch(e.FormattedValue.ToString(), regexForInt))
                    {
                        dataGridView1.Rows[e.RowIndex].ErrorText =
                            "Номер квартиры должен быть целым положительным числом";
                        e.Cancel = true;
                    }
                }
                else if (headerText.Equals("Аренда"))
                {
                    if (!Regex.IsMatch(e.FormattedValue.ToString(), regexForDouble))
                    {
                        dataGridView1.Rows[e.RowIndex].ErrorText =
                            "Аренда должна быть неотрицательным числом";
                        e.Cancel = true;
                    }
                }
                else if (headerText.Equals("Электроэнергия"))
                {
                    if (!Regex.IsMatch(e.FormattedValue.ToString(), regexForDouble))
                    {
                        dataGridView1.Rows[e.RowIndex].ErrorText =
                            "Электроэнергия должна быть неотрицательным числом";
                        e.Cancel = true;
                    }
                }
                else if (headerText.Equals("Вода холодная"))
                {
                    if (!Regex.IsMatch(e.FormattedValue.ToString(), regexForDouble))
                    {
                        dataGridView1.Rows[e.RowIndex].ErrorText =
                            "Объём холодной воды должен быть неотрицательным числом";
                        e.Cancel = true;
                    }
                }
                else if (headerText.Equals("Вода горячая"))
                {
                    if (!Regex.IsMatch(e.FormattedValue.ToString(), regexForDouble))
                    {
                        dataGridView1.Rows[e.RowIndex].ErrorText =
                            "Объём горячей воды должен быть неотрицательным числом";
                        e.Cancel = true;
                    }
                }
                else if (headerText.Equals("Газ"))
                {
                    if (!Regex.IsMatch(e.FormattedValue.ToString(), regexForDouble))
                    {
                        dataGridView1.Rows[e.RowIndex].ErrorText =
                            "Объём газа должен быть неотрицательным числом";
                        e.Cancel = true;
                    }
                }
            }
        }

        /// <summary>
        /// Обработка нажатия по пункту меню для удаления выделенных строк
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void RemoveNote_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Index == dataGridView1.Rows.Count - 1)
                    return;
                var id = int.Parse(row.Cells[0].Value.ToString());
                bool isTenantsLive = db.Tenants.Where(item => item.flatId == id).Any();
                if (isTenantsLive)
                {
                    row.ErrorText = "Для удаления этой квартиры сначала удалите жильцов, которые в ней проживают";
                }
                else
                {
                    dataGridView1.Rows.Remove(row);
                    changedFlats.Remove(changedFlats.Find(it => it.flatId == id));
                    FixLastRowId();
                }
            }
        }

        /// <summary>
        /// Позволяет при закрытии формы закрыть и приложение
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void FlatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Filter(decimal val, Flat flat)
        {
            if (field.SelectedIndex == 0)
            {
                AddToGridIfNeed(val, flat, flat.flat_num);
            }
            else if (field.SelectedIndex == 1)
            {
                AddToGridIfNeed(val, flat, flat.rent);
            }
            else if (field.SelectedIndex == 2)
            {
                AddToGridIfNeed(val, flat, flat.energy);
            }
            else if (field.SelectedIndex == 3)
            {
                AddToGridIfNeed(val, flat, flat.cold_water);
            }
            else if (field.SelectedIndex == 4)
            {
                AddToGridIfNeed(val, flat, flat.hot_water);
            }
            else if (field.SelectedIndex == 5)
            {
                AddToGridIfNeed(val, flat, flat.gas);
            }
        }

        private void AddToGridIfNeed(decimal val, Flat flat, decimal flatVal)
        {
            if (biggerOrLower.SelectedIndex == 0)
            {
                if (flatVal > val)
                {
                    AddToGrid(flat);
                }
            }
            else if (biggerOrLower.SelectedIndex == 1)
            {
                if (flatVal < val)
                {
                    AddToGrid(flat);
                }
            }
            else if (biggerOrLower.SelectedIndex == 2)
            {
                if (flatVal == val)
                {
                    AddToGrid(flat);
                }
            }
        }

        /// <summary>
        /// Обработка вводимого текста для фильтрации
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Value_TextChanged(object sender, EventArgs e)
        {
            var text = value.Text;
            string regexForDouble = "^\\d{1,10}(|[\\,\\.]\\d+)$";
            if (Regex.IsMatch(text, regexForDouble))
            {
                value.BackColor = Color.White;
                var val = decimal.Parse(text);
                dataGridView1.Rows.Clear();
                foreach (Flat flat in changedFlats)
                {
                    Filter(val, flat);
                }
            }
            else
            {
                value.BackColor = Color.Red;
            }
            FixLastRowId();
        }

        /// <summary>
        /// Обработка изменения значения ComboBox, который позволяет выбрать знак для фильтрации
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void BiggerOrLower_SelectedIndexChanged(object sender, EventArgs e)
        {
            Value_TextChanged(null, null);
        }

        /// <summary>
        /// Обработка изменения значения ComboBox, который выбирает колонку для фильтрации
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Field_SelectedIndexChanged(object sender, EventArgs e)
        {
            Value_TextChanged(null, null);
        }

        /// <summary>
        /// Обработка выхода за пределы таблицы для валидации значений всех ячеек
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void DataGridView1_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                var row = dataGridView1.Rows[i];
                if (row.Cells[1].Value == null)
                {
                    row.ErrorText += "Номер не может быть пустым";
                    save.Enabled = false;
                }
                else if (row.Cells[2].Value == null)
                {
                    row.ErrorText += "Аренда не может быть пустой";
                    save.Enabled = false;
                }
                else if (row.Cells[3].Value == null)
                {
                    row.ErrorText += "Электроэнергия не может быть пустой";
                    save.Enabled = false;
                }
                else if (row.Cells[4].Value == null)
                {
                    row.ErrorText += "Холодная вода не может быть пустой";
                    save.Enabled = false;
                }
                else if (row.Cells[5].Value == null)
                {
                    row.ErrorText += "Горячая вода не может быть пустой";
                    save.Enabled = false;
                }
                else if (row.Cells[6].Value == null)
                {
                    row.ErrorText += "Газ не может быть пустым";
                    save.Enabled = false;
                }
                else
                {
                    save.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Обработка вводимого текста в поле поиска
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Search_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Flat flat in changedFlats)
            {
                var text = search.Text;
                if (flat.flatId.ToString().Contains(text)
                    || flat.flat_num.ToString().Contains(text)
                    || flat.energy.ToString().Contains(text)
                    || flat.rent.ToString().Contains(text)
                    || flat.hot_water.ToString().Contains(text)
                    || flat.cold_water.ToString().Contains(text)
                    || flat.gas.ToString().Contains(text))
                {
                    AddToGrid(flat);
                }
            }
            FixLastRowId();
        }

        /// <summary>
        /// Окончание ввода в ячейку
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;

            string headerText =
                dataGridView1.Columns[e.ColumnIndex].HeaderText;

            if (IsFiltering || IsSearching)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                var flat = changedFlats.Find(item => item.flatId == id);

                if(flat == null)
                {
                    flat = new Flat(id, 0, 0, 0, 0, 0, 0);
                    changedFlats.Add(flat);
                }

                if (headerText.Equals("Номер"))
                {
                    flat.flat_num = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
                else if (headerText.Equals("Аренда"))
                {
                    flat.rent = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                }
                else if (headerText.Equals("Электроэнергия"))
                {
                    flat.energy = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
                else if (headerText.Equals("Вода холодная"))
                {
                    flat.cold_water = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
                else if (headerText.Equals("Вода горячая"))
                {
                    flat.hot_water = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
                else if (headerText.Equals("Газ"))
                {
                    flat.gas = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                }
            }
        }

        /// <summary>
        /// Обработка добавления строки
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int max = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                    if (max < int.Parse(row.Cells[0].Value.ToString()))
                    {
                        max = int.Parse(row.Cells[0].Value.ToString());
                    }
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null)
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = max + 1;
        }
    }
}
