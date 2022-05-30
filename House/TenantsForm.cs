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
    /// Частичный класс для отображения таблицы жильцов
    /// </summary>
    public partial class TenantsForm : Form
    {
        private AppContext db;
        private FlatForm flatForm;
        private bool IsSearching = false;
        private bool IsFiltering = false;

        private List<Tenant> changedTenants;
        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public TenantsForm()
        {
            InitializeComponent();
            db = new AppContext();
            flatForm = new FlatForm();
            flatForm.Hide();
            search.Hide();
            value.Hide();
            biggerOrLower.Hide();
            field.Hide();
            changedTenants = new List<Tenant>();
            dataGridView1.Rows[0].Cells[0].Value = 1;
            Load_Click(null, null);
        }

        /// <summary>
        /// Обработка нажатия по пункту меню для перехода к таблице квартир
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void GoToFlats_Click(object sender, EventArgs e)
        {
            Hide();
            flatForm.Show();
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
                search.Show();
                search.Focus();
                search.Clear();
                value.Hide();
                biggerOrLower.Hide();
                field.Hide();
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
        /// Обработка нажатия по пункту меню для добавления новой строки
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Add_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            FixLastRowId();
        }

        /// <summary>
        /// Обработка нажатия по пункту меню для сохранения данных в БД
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Save_Click(object sender, EventArgs e)
        {
            if (IsFiltering|| IsSearching)
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
            foreach(Tenant tenant in db.Tenants)
            {
                if (checkToDelete(tenant))
                {
                    db.Tenants.Remove(tenant);
                }
            }
            db.SaveChanges();
            Load_Click(null, null);
        }

        private bool checkToDelete(Tenant tenant)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index + 1 != dataGridView1.Rows.Count)
                {
                    if (row.Cells[0].Value.ToString().Equals(tenant.tenantId.ToString()))
                    {
                        return false;
                    }
                    
                }
                   
            }
            return true;
        }

        /// <summary>
        /// Обработка нажатия по пункту меню для загрузки данных из БД
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Load_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Tenant tenant in db.Tenants)
            {
                AddToGrid(tenant);
            }
            changedTenants = new List<Tenant>(db.Tenants.AsEnumerable());
            search.Hide();
            dataGridView1.Location = new Point(dataGridView1.Location.X, 23);
            HideFilterFields();
            FixLastRowId();
        }

        private void FixLastRowId()
        {
            int max = 0;
            if (dataGridView1.Rows.Count < changedTenants.Count)
            {

                foreach (Tenant tenant in changedTenants)
                {
                        if (max < tenant.tenantId)
                        {
                            max = tenant.tenantId;
                        }
                }

            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index != dataGridView1.Rows.Count - 1)
                        if (max < int.Parse(row.Cells[0].Value.ToString()))
                        {
                            max = int.Parse(row.Cells[0].Value.ToString());
                        }
                }
            }
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = max + 1;
        }

        private void HideFilterFields()
        {
            value.Hide();
            field.Hide();
            biggerOrLower.Hide();
        }

        /// <summary>
        /// Обработка нажатия по пункту меню для очистки всей таблицы
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Delete_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            changedTenants.Clear();
            dataGridView1.Rows[0].Cells[0].Value = 1;
        }

        /// <summary>
        /// Обработка нажатия по пункту меню для открытия или сокрытия компонентов, с помощью которых осуществляется фильтрация
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
                value.Show();
                biggerOrLower.Show();
                field.Show();
                dataGridView1.Location = new Point(dataGridView1.Location.X, 23);
                SaveValues();
            }
            else
            {
                search.Hide();
                value.Hide();
                biggerOrLower.Hide();
                field.Hide();
                dataGridView1.Location = new Point(dataGridView1.Location.X, 23);
                RestoreValues();
            }
        }

        private void SaveValues()
        {
            changedTenants.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index + 1 != dataGridView1.Rows.Count)
                    if (row.Cells[0].Value != null)
                    {
                        changedTenants.Add(
                           new Tenant(int.Parse(row.Cells[0].Value.ToString().Replace(".", ",")),
                               (row.Cells[1].Value ?? "").ToString(),
                              (row.Cells[2].Value ?? "").ToString(),
                              (row.Cells[3].Value ?? "").ToString(),
                              decimal.Parse(row.Cells[4].Value.ToString().Replace(".", ",")),
                              int.Parse(row.Cells[5].Value.ToString().Replace(".", ","))
                          )
                     );
                    }
                    else
                    {
                        changedTenants.Add(new Tenant((row.Cells[1].Value ?? "").ToString(),
                           (row.Cells[2].Value ?? "").ToString(),
                            (row.Cells[3].Value ?? "").ToString(),
                           decimal.Parse(row.Cells[4].Value.ToString().Replace(".", ",")),
                           int.Parse(row.Cells[5].Value.ToString().Replace(".", ","))
                       )
                      );
                    }
            }
        }

        private void RestoreValues()
        {
            dataGridView1.Rows.Clear();
            foreach (Tenant tenant in changedTenants)
            {
                AddToGrid(tenant);
            }
            changedTenants.Clear();
            FixLastRowId();
        }

        private void AddToGrid(Tenant tenant)
        {
            dataGridView1.Rows.Add(tenant.tenantId, tenant.name, tenant.surname, tenant.patronymic, tenant.income, tenant.flatId);
        }

        /// <summary>
        /// Обработка нажатия по пункту меню для удаления выделенных строк
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void DeleteNote_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            FixLastRowId();
        }

        private void SaveFromGrid(DataGridViewRow row)
        {
            var id = int.Parse(row.Cells[0].Value.ToString().Replace(".", ","));
            if (db.Tenants.Find(id) != null)
            {
                db.Tenants.Find(id).name = (row.Cells[1].Value ?? "").ToString();
                db.Tenants.Find(id).surname = (row.Cells[2].Value ?? "").ToString();
                db.Tenants.Find(id).patronymic = (row.Cells[3].Value ?? "").ToString();
                db.Tenants.Find(id).income = decimal.Parse(row.Cells[4].Value.ToString().Replace(".", ","));
                db.Tenants.Find(id).flatId = int.Parse(row.Cells[5].Value.ToString().Replace(".", ","));
            }
            else
            {
                db.Tenants.Add(new Tenant(id,(row.Cells[1].Value ?? "").ToString(),
                    (row.Cells[2].Value ?? "").ToString(),
                    (row.Cells[3].Value ?? "").ToString(),
                    decimal.Parse(row.Cells[4].Value.ToString().Replace(".", ",")),
                    int.Parse(row.Cells[5].Value.ToString().Replace(".", ","))
                )
               );
            }
        }

        /// <summary>
        /// Обработка текста, вводимого в поле для поиска
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Search_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Tenant tenant in changedTenants)
            {
                var text = search.Text;
                if (tenant.tenantId.ToString().Contains(text)
                    || tenant.name.Contains(text)
                    || tenant.surname.Contains(text)
                    || tenant.patronymic.Contains(text)
                    || tenant.income.ToString().Contains(text)
                    || tenant.flatId.ToString().Equals(text))
                {
                    AddToGrid(tenant);
                }
            }
            FixLastRowId();
        }

        /// <summary>
        /// Валидация данных при попытке выхода из редактирования ячейки
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
                if (headerText.Equals("Доход"))
                {
                    if (!Regex.IsMatch(e.FormattedValue.ToString(), regexForDouble))
                    {
                        dataGridView1.Rows[e.RowIndex].ErrorText =
                            "Доход должен быть дробным неотрицательным числом";
                        e.Cancel = true;
                    }
                }
                else if (headerText.Equals("Квартира id"))
                {
                    if (!Regex.IsMatch(e.FormattedValue.ToString(), regexForInt))
                    {
                        dataGridView1.Rows[e.RowIndex].ErrorText =
                            "Квартира должна быть целым положительным числом";
                        e.Cancel = true;
                    }
                    else
                    {
                        var val = int.Parse(e.FormattedValue.ToString());
                        var result = db.Flats.FirstOrDefault(item => item.flatId == val); 
                        if(result == null)
                        {
                            dataGridView1.Rows[e.RowIndex].ErrorText =
                            "Квартиры с таким id не существует";
                            save.Enabled = false;
                        }
                        else
                        {
                            save.Enabled = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Обработка окончания ввода в ячейку
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
                var tenant = changedTenants.Find(item => item.tenantId == id);
                if(tenant == null)
                {
                    tenant = new Tenant(id, "", "", "", 0, 0); 
                    changedTenants.Add(tenant);
                }
                if (headerText.Equals("Доход"))
                {
                    tenant.income = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
                else if (headerText.Equals("Квартира id"))
                {
                    tenant.flatId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
                else if (headerText.Equals("Имя"))
                {
                    tenant.name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
                else if (headerText.Equals("Фамилия"))
                {
                    tenant.surname = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
                else if (headerText.Equals("Отчество"))
                {
                    tenant.patronymic = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
            }
        }

        /// <summary>
        /// Обработка закрытия формы для одновременного закрытия приложения
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void TenantsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Обработка текста, вводимого в поле фильтрации
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Value_TextChanged(object sender, EventArgs e)
        {
            var text = value.Text;
            string regexForDouble = "^\\d{1,10}(|[\\,\\.]\\d+)$";
            if (Regex.IsMatch(text, regexForDouble)) {
                value.BackColor = Color.White;
                var val = decimal.Parse(text);
                dataGridView1.Rows.Clear();
                foreach (Tenant tenant in changedTenants)
                {
                    Filter(val, tenant);
                }
            } else
            {
                value.BackColor = Color.Red;
            }
            FixLastRowId();
        }

        private void Filter(decimal val, Tenant tenant)
        {
            if (field.SelectedIndex == 0)
            {
                AddTenantIfNeed(val, tenant, tenant.flatId);
            }
            else if (field.SelectedIndex == 1)
            {
                AddTenantIfNeed(val, tenant, tenant.income);
            }
        }

        private void AddTenantIfNeed(decimal val, Tenant tenant, decimal tenantVal)
        {
            if (biggerOrLower.SelectedIndex == 0)
            {
                if (tenantVal > val)
                {
                    AddToGrid(tenant);
                }
            }
            else if (biggerOrLower.SelectedIndex == 1)
            {
                if (tenantVal < val)
                {
                    AddToGrid(tenant);
                }
            }
            else if (biggerOrLower.SelectedIndex == 2)
            {
                if (tenantVal == val)
                {
                    AddToGrid(tenant);
                }
            }
        }

        /// <summary>
        /// Обработка изменения значения ComboBox, отвечающего за выбор знака для фильтрации
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void BiggerOrLower_SelectedIndexChanged(object sender, EventArgs e)
        {
            Value_TextChanged(null, null);
        }

        /// <summary>
        /// Обработка изменения значения ComboBox, отвечающего за выбор колонки для фильтрации
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void Field_SelectedIndexChanged(object sender, EventArgs e)
        {
            Value_TextChanged(null, null);
        }

        /// <summary>
        /// Обработка выхода за пределы таблицы для валидации всех ячеек
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Event</param>
        public void DataGridView1_MouseLeave(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                var row = dataGridView1.Rows[i];
                if (row.Cells[4].Value == null)
                {
                    row.ErrorText += "Доход не может быть пустым";
                    save.Enabled = false;
                }
                else if (row.Cells[5].Value == null)
                {
                    row.ErrorText += "Id квартиры не может быть пустым";
                    save.Enabled = false;
                } 
                else
                {
                    var val = int.Parse(row.Cells[5].Value.ToString());
                    var result = db.Flats.FirstOrDefault(item => item.flatId == val);
                    if (result == null)
                    {
                        row.ErrorText =
                        "Квартиры с таким id не существует";
                        save.Enabled = false;
                    }
                    else
                    {
                        save.Enabled = true;
                    }
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
                if(row.Cells[0].Value != null)
                if(max < int.Parse(row.Cells[0].Value.ToString()))
                {
                    max = int.Parse(row.Cells[0].Value.ToString());
                }
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null)
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = max + 1;
        }
    }
}
