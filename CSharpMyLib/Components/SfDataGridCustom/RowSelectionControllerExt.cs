using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpMyLib.Components.SfDataGridCustom
{
    public class RowSelectionControllerExt : RowSelectionController
    {
        SfDataGrid DataGrid;

        public RowSelectionControllerExt(SfDataGrid sfDataGrid)
            : base(sfDataGrid)
        {
            this.DataGrid = sfDataGrid;
        }

        protected override void HandleKeyOperations(KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Enter)
            {
                KeyEventArgs arguments = new KeyEventArgs(Keys.Tab);
                base.HandleKeyOperations(arguments);
                return;
            }

            base.HandleKeyOperations(args);
        }
    }
}
