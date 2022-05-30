
namespace House
{
    partial class FlatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlatForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.таблицаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.load = new System.Windows.Forms.ToolStripMenuItem();
            this.filter = new System.Windows.Forms.ToolStripMenuItem();
            this.goToTenants = new System.Windows.Forms.ToolStripMenuItem();
            this.записьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.find = new System.Windows.Forms.ToolStripMenuItem();
            this.add = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNote = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enegry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldWater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotWater = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.search = new System.Windows.Forms.TextBox();
            this.field = new System.Windows.Forms.ComboBox();
            this.biggerOrLower = new System.Windows.Forms.ComboBox();
            this.value = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицаToolStripMenuItem,
            this.записьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // таблицаToolStripMenuItem
            // 
            this.таблицаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.load,
            this.filter,
            this.goToTenants});
            this.таблицаToolStripMenuItem.Name = "таблицаToolStripMenuItem";
            this.таблицаToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.таблицаToolStripMenuItem.Text = "Таблица";
            // 
            // save
            // 
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(184, 22);
            this.save.Text = "Сохранить";
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // load
            // 
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(184, 22);
            this.load.Text = "Загрузить";
            this.load.Click += new System.EventHandler(this.Load_Click);
            // 
            // filter
            // 
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(184, 22);
            this.filter.Text = "Фильтровать";
            this.filter.Click += new System.EventHandler(this.Filter_Click);
            // 
            // goToTenants
            // 
            this.goToTenants.Name = "goToTenants";
            this.goToTenants.Size = new System.Drawing.Size(184, 22);
            this.goToTenants.Text = "Перейти к жильцам";
            this.goToTenants.Click += new System.EventHandler(this.GoToTenants_Click);
            // 
            // записьToolStripMenuItem
            // 
            this.записьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.find,
            this.add,
            this.removeNote});
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
            // removeNote
            // 
            this.removeNote.Name = "removeNote";
            this.removeNote.Size = new System.Drawing.Size(126, 22);
            this.removeNote.Text = "Удалить";
            this.removeNote.Click += new System.EventHandler(this.RemoveNote_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.flat,
            this.rent,
            this.enegry,
            this.coldWater,
            this.hotWater,
            this.gas});
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 411);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellEndEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridView1_CellValidating);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridView1_RowsAdded);
            this.dataGridView1.MouseLeave += new System.EventHandler(this.DataGridView1_MouseLeave);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // flat
            // 
            this.flat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.flat.HeaderText = "Номер";
            this.flat.Name = "flat";
            // 
            // rent
            // 
            this.rent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rent.HeaderText = "Аренда";
            this.rent.Name = "rent";
            // 
            // enegry
            // 
            this.enegry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.enegry.HeaderText = "Электроэнергия";
            this.enegry.Name = "enegry";
            // 
            // coldWater
            // 
            this.coldWater.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.coldWater.HeaderText = "Вода холодная";
            this.coldWater.Name = "coldWater";
            // 
            // hotWater
            // 
            this.hotWater.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hotWater.HeaderText = "Вода горячая";
            this.hotWater.Name = "hotWater";
            // 
            // gas
            // 
            this.gas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gas.HeaderText = "Газ";
            this.gas.Name = "gas";
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search.Location = new System.Drawing.Point(12, 28);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(776, 20);
            this.search.TabIndex = 2;
            this.search.TextChanged += new System.EventHandler(this.Search_TextChanged);
            // 
            // field
            // 
            this.field.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.field.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.field.FormattingEnabled = true;
            this.field.Items.AddRange(new object[] {
            "Номер",
            "Аренда",
            "Электроэнергия",
            "Вода холодная",
            "Вода горячая",
            "Газ"});
            this.field.Location = new System.Drawing.Point(13, 461);
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
            this.biggerOrLower.Location = new System.Drawing.Point(163, 461);
            this.biggerOrLower.Name = "biggerOrLower";
            this.biggerOrLower.Size = new System.Drawing.Size(41, 21);
            this.biggerOrLower.TabIndex = 4;
            this.biggerOrLower.SelectedIndexChanged += new System.EventHandler(this.BiggerOrLower_SelectedIndexChanged);
            // 
            // value
            // 
            this.value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.value.Location = new System.Drawing.Point(240, 461);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(100, 20);
            this.value.TabIndex = 5;
            this.value.TextChanged += new System.EventHandler(this.Value_TextChanged);
            // 
            // FlatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.value);
            this.Controls.Add(this.biggerOrLower);
            this.Controls.Add(this.field);
            this.Controls.Add(this.search);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FlatForm";
            this.Text = "Квартиры";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FlatForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem таблицаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.ToolStripMenuItem load;
        private System.Windows.Forms.ToolStripMenuItem filter;
        private System.Windows.Forms.ToolStripMenuItem записьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem find;
        private System.Windows.Forms.ToolStripMenuItem add;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem goToTenants;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn flat;
        private System.Windows.Forms.DataGridViewTextBoxColumn rent;
        private System.Windows.Forms.DataGridViewTextBoxColumn enegry;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldWater;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotWater;
        private System.Windows.Forms.DataGridViewTextBoxColumn gas;
        private System.Windows.Forms.ToolStripMenuItem removeNote;
        private System.Windows.Forms.ComboBox field;
        private System.Windows.Forms.ComboBox biggerOrLower;
        private System.Windows.Forms.TextBox value;
    }
}