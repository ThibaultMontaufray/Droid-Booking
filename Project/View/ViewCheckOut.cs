using Droid.People;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid.Booking
{
    public class ViewCheckOut : UserControlCustom, IView
    {
        #region Attribute
        private InterfaceBooking _intBoo;
        
        private PrintDocument printdoc1 = new PrintDocument();
        private PrintPreviewDialog previewdlg = new PrintPreviewDialog();
        private Panel pannelPrinterPreview = null;
        private Bitmap MemoryImage;

        private Panel panelTop;
        private Label labelArrivals;
        private PictureBox pictureBox1;
        private Label labelCheckOut;
        private Label labelDate;
        private Label labelBottom;
        private Button buttonPrint;
        private Panel panelPrinter;
        private DataGridView dataGridViewCheckOut;
        private DataGridViewTextBoxColumn ColumnType;
        private DataGridViewTextBoxColumn ColumnName;
        private DataGridViewTextBoxColumn ColumnPerson;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewCheckOut()
        {
            InitializeComponent();
            Init();
        }
        public ViewCheckOut(InterfaceBooking intBoo)
        {
            _intBoo = intBoo;

            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public void ChangeLanguage()
        {
            ColumnType.HeaderText = GetText.Text("Type");
            ColumnPerson.HeaderText = GetText.Text("User");
            ColumnName.HeaderText = GetText.Text("Name");

            RefreshData();
        }
        public override void RefreshData()
        {
            Person person;
            DataGridViewRow row;

            dataGridViewCheckOut.Rows.Clear();
            foreach (Booking booking in _intBoo.Bookings.Where(b => b.CheckOut.Date.Equals(DateTime.Now.Date)))
            {
                dataGridViewCheckOut.Rows.Add();
                row = dataGridViewCheckOut.Rows[dataGridViewCheckOut.Rows.Count - 1];
                row.Cells[ColumnName.Index].Value = Area.GetAreaFromId(booking.AreaId, _intBoo.Areas).Name;
                row.Cells[ColumnType.Index].Value = Area.GetAreaFromId(booking.AreaId, _intBoo.Areas).Type;

                person = Person.GetPersonFromId(booking.UserId, _intBoo.Persons);
                if (person != null) row.Cells[ColumnPerson.Index].Value = string.Format("{0} {1}", person.FirstName.Value, person.Name);
            }

            labelDate.Text = DateTime.Now.ToShortDateString();
            labelCheckOut.Text = GetText.Text("DailyCheckOut");
            labelArrivals.Text = string.Format("{0} {1}", dataGridViewCheckOut.Rows.Count, GetText.Text("departures"));
        }
        #endregion

        #region Methods protected
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {
            printdoc1.DocumentName = string.Format("{0} - {1}", GetText.Text("CheckOut"), DateTime.Now.Date);
            printdoc1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCheckOut));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.labelArrivals = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelCheckOut = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelBottom = new System.Windows.Forms.Label();
            this.panelPrinter = new System.Windows.Forms.Panel();
            this.dataGridViewCheckOut = new System.Windows.Forms.DataGridView();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelPrinter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheckOut)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.buttonPrint);
            this.panelTop.Controls.Add(this.labelArrivals);
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.labelCheckOut);
            this.panelTop.Controls.Add(this.labelDate);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(500, 100);
            this.panelTop.TabIndex = 1;
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.Transparent;
            this.buttonPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPrint.BackgroundImage")));
            this.buttonPrint.FlatAppearance.BorderSize = 0;
            this.buttonPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Location = new System.Drawing.Point(455, 10);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(32, 32);
            this.buttonPrint.TabIndex = 4;
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // labelArrivals
            // 
            this.labelArrivals.AutoSize = true;
            this.labelArrivals.Location = new System.Drawing.Point(105, 68);
            this.labelArrivals.Name = "labelArrivals";
            this.labelArrivals.Size = new System.Drawing.Size(77, 15);
            this.labelArrivals.TabIndex = 3;
            this.labelArrivals.Text = "0 departures";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 76);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labelCheckOut
            // 
            this.labelCheckOut.AutoSize = true;
            this.labelCheckOut.Location = new System.Drawing.Point(105, 43);
            this.labelCheckOut.Name = "labelCheckOut";
            this.labelCheckOut.Size = new System.Drawing.Size(91, 15);
            this.labelCheckOut.TabIndex = 1;
            this.labelCheckOut.Text = "Daily check out";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(104, 12);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(48, 23);
            this.labelDate.TabIndex = 0;
            this.labelDate.Text = "Date";
            // 
            // labelBottom
            // 
            this.labelBottom.BackColor = System.Drawing.Color.White;
            this.labelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelBottom.Location = new System.Drawing.Point(0, 577);
            this.labelBottom.Name = "labelBottom";
            this.labelBottom.Size = new System.Drawing.Size(500, 23);
            this.labelBottom.TabIndex = 2;
            this.labelBottom.Text = "Powered by ServOdroid  Inc. (copyright 2017) Droid-booking";
            this.labelBottom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelPrinter
            // 
            this.panelPrinter.Controls.Add(this.dataGridViewCheckOut);
            this.panelPrinter.Controls.Add(this.panelTop);
            this.panelPrinter.Controls.Add(this.labelBottom);
            this.panelPrinter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrinter.Location = new System.Drawing.Point(0, 0);
            this.panelPrinter.Name = "panelPrinter";
            this.panelPrinter.Size = new System.Drawing.Size(500, 600);
            this.panelPrinter.TabIndex = 4;
            // 
            // dataGridViewCheckOut
            // 
            this.dataGridViewCheckOut.AllowUserToAddRows = false;
            this.dataGridViewCheckOut.AllowUserToDeleteRows = false;
            this.dataGridViewCheckOut.AllowUserToResizeColumns = false;
            this.dataGridViewCheckOut.AllowUserToResizeRows = false;
            this.dataGridViewCheckOut.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCheckOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCheckOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnType,
            this.ColumnName,
            this.ColumnPerson});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckOut.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCheckOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCheckOut.Location = new System.Drawing.Point(0, 100);
            this.dataGridViewCheckOut.Name = "dataGridViewCheckOut";
            this.dataGridViewCheckOut.RowHeadersVisible = false;
            this.dataGridViewCheckOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCheckOut.Size = new System.Drawing.Size(500, 477);
            this.dataGridViewCheckOut.TabIndex = 4;
            // 
            // ColumnType
            // 
            this.ColumnType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.Width = 56;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 60;
            // 
            // ColumnUser
            // 
            this.ColumnPerson.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPerson.HeaderText = "User";
            this.ColumnPerson.Name = "ColumnUser";
            // 
            // ViewCheckOut
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelPrinter);
            this.Name = "ViewCheckOut";
            this.Size = new System.Drawing.Size(500, 600);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelPrinter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheckOut)).EndInit();
            this.ResumeLayout(false);

        }
        private void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            Rectangle rect = new Rectangle(0, 0, pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        #endregion

        #region Event
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            buttonPrint.Visible = false;
            pannelPrinterPreview = panelPrinter;
            GetPrintArea(panelPrinter);
            previewdlg.Document = printdoc1;
            buttonPrint.Visible = true;
            (previewdlg as Form).Icon = Properties.Resources.ServoIconReservation;
            previewdlg.ShowDialog();
        }
        private void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (pannelPrinterPreview.Width / 2), pannelPrinterPreview.Location.Y);
        }
        #endregion
    }
}
