
namespace House
{
    partial class TenantsForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenantsForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.таблицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.load = new System.Windows.Forms.ToolStripMenuItem();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.filter = new System.Windows.Forms.ToolStripMenuItem();
            this.goToFlats = new System.Windows.Forms.ToolStripMenuItem();
            this.записьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.find = new System.Windows.Forms.ToolStripMenuItem();
            this.add = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteNote = new System.Windows.Forms.ToolStripMenuItem();
            this.search = new System.Windows.Forms.TextBox();
            this.field = new System.Windows.Forms.ComboBox();
            this.biggerOrLower = new System.Windows.Forms.ComboBox();
            this.value = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.income = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.Surname,
            this.patronymic,
            this.income,
            this.flatId});
            this.dataGridView1.Location = new System.Drawing.Point(12, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(782, 421);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellEndEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridView1_CellValidating);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridView1_RowsAdded);
            this.dataGridView1.MouseLeave += new System.EventHandler(this.DataGridView1_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицаToolStripMenuItem,
            this.записьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // таблицаToolStripMenuItem
            // 
            this.таблицаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.load,
            this.delete,
            this.filter,
            this.goToFlats});
            this.таблицаToolStripMenuItem.Name = "таблицаToolStripMenuItem";
            this.таблицаToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.таблицаToolStripMenuItem.Text = "Таблица";
            // 
            // save
            // 
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(192, 22);
            this.save.Text = "Сохранить";
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // load
            // 
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(192, 22);
            this.load.Text = "Загрузить";
            this.load.Click += new System.EventHandler(this.Load_Click);
            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(192, 22);
            this.delete.Text = "Удалить";
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // filter
            // 
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(192, 22);
            this.filter.Text = "Фильтрация";
            this.filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // goToFlats
            // 
            this.goToFlats.Name = "goToFlats";
            this.goToFlats.Size = new System.Drawing.Size(192, 22);
            this.goToFlats.Text = "Перейти к квартирам";
            this.goToFlats.Click += new System.EventHandler(this.GoToFlats_Click);
            // 
            // записьToolStripMenuItem
            // 
            this.записьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.find,
            this.add,
            this.deleteNote});
            this.записьToolStripMenuItem.Name = "записьToolStripMenuItem";
            this.записьToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.записьToolStripMenuItem.Text = "Запись";
            // 
            // find
            // 
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(126, 22);
            this.find.Text = "Найти";
            this.find.Click += new System.EventHandler(this.Find_Click);
            // 
            // add
            // 
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(126, 22);
            this.add.Text = "Добавить";
            this.add.Click += new System.EventHandler(this.Add_Click);
            // 
            // deleteNote
            // 
            this.deleteNote.Name = "deleteNote";
            this.deleteNote.Size = new System.Drawing.Size(126, 22);
            this.deleteNote.Text = "Удалить";
            this.deleteNote.Click += new System.EventHandler(this.DeleteNote_Click);
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search.Location = new System.Drawing.Point(12, 23);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(780, 20);
            this.search.TabIndex = 2;
            this.search.TextChanged += new System.EventHandler(this.Search_TextChanged);
            // 
            // field
            // 
            this.field.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.field.Cursor = System.Windows.Forms.Cursors.Default;
            this.field.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.field.Items.AddRange(new object[] {
            "Квартира",
            "Доход"});
            this.field.Location = new System.Drawing.Point(12, 457);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(121, 21);
            this.field.TabIndex = 3;
            this.field.SelectedIndexChanged += new System.EventHandler(this.Field_SelectedIndexChanged);
            // 
            // biggerOrLower
            // 
            this.biggerOrLower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.biggerOrLower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.biggerOrLower.FormattingEnabled = true;
            this.biggerOrLower.Items.AddRange(new object[] {
            ">",
            "<",
            "="});
            this.biggerOrLower.Location = new System.Drawing.Point(166, 457);
            this.biggerOrLower.Name = "biggerOrLower";
            this.biggerOrLower.Size = new System.Drawing.Size(43, 21);
            this.biggerOrLower.TabIndex = 4;
            this.biggerOrLower.SelectedIndexChanged += new System.EventHandler(this.BiggerOrLower_SelectedIndexChanged);
            // 
            // value
            // 
            this.value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.value.Location = new System.Drawing.Point(236, 457);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(100, 20);
            this.value.TabIndex = 5;
            this.value.TextChanged += new System.EventHandler(this.Value_TextChanged);
            // 
            // id
            // 
            this.id.Frozen = true;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.name.Frozen = true;
            this.name.HeaderText = "Имя";
            this.name.Name = "name";
            this.name.Width = 147;
            // 
            // Surname
            // 
            this.Surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Surname.HeaderText = "Фамилия";
            this.Surname.Name = "Surname";
            // 
            // patronymic
            // 
            this.patronymic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.patronymic.HeaderText = "Отчество";
            this.patronymic.Name = "patronymic";
            // 
            // income
            // 
            this.income.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.income.HeaderText = "Доход";
            this.income.Name = "income";
            // 
            // flatId
            // 
            this.flatId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.flatId.HeaderText = "Квартира id";
            this.flatId.Name = "flatId";
            // 
            // TenantsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(804, 490);
            this.Controls.Add(this.value);
            this.Controls.Add(this.biggerOrLower);
            this.Controls.Add(this.field);
            this.Controls.Add(this.search);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TenantsForm";
            this.Text = "Жильцы";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TenantsForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem таблицаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.ToolStripMenuItem load;
        private System.Windows.Forms.ToolStripMenuItem delete;
        private System.Windows.Forms.ToolStripMenuItem записьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem find;
        private System.Windows.Forms.ToolStripMenuItem add;
        private System.Windows.Forms.ToolStripMenuItem filter;
        private System.Windows.Forms.ToolStripMenuItem goToFlats;
        private System.Windows.Forms.ToolStripMenuItem deleteNote;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.ComboBox field;
        private System.Windows.Forms.ComboBox biggerOrLower;
        private System.Windows.Forms.TextBox value;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn income;
        private System.Windows.Forms.DataGridViewTextBoxColumn flatId;
    }
}

