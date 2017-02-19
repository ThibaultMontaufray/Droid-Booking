using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Droid_Booking
{
    public partial class ViewBookEdit : UserControl
    {
        #region Attribute
        private Interface_booking _intBoo;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewBookEdit()
        {
            InitializeComponent();
            Init();
        }
        public ViewBookEdit(Interface_booking intBoo)
        {
            _intBoo = intBoo;

            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void Init()
        {
            if (_intBoo != null)
            {
                comboBoxArea.Items.Clear();
                foreach (var item in _intBoo.Areas)
                {
                    comboBoxArea.Items.Add(item.Type.ToString() + " - " + item.Name);
                }
                comboBoxUser.Items.Clear();
                foreach (var item in _intBoo.Users)
                {
                    comboBoxUser.Items.Add(item.FirstName + " " + item.FamilyName);
                }
            }
        }
        #endregion

        #region Event
        private void buttonAddUser_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
