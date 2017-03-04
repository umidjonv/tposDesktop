using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Classes.GridCells
{
    class ImageCell:DataGridViewButtonCell
    {
        public Image Img;
        
        
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            if(Img!=null)
            graphics.DrawImage(Img, cellBounds);
        }
    }
    public class ImageButtonColumn : DataGridViewButtonColumn
    {
        public ImageButtonColumn()
        {
            this.CellTemplate = new ImageCell(); 
        }
        public void SetImage(Image img)
        {
            ImageCell imgC = this.CellTemplate as ImageCell;
            imgC.Img = img;
        }
    }
}
