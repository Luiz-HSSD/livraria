using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils
{
    public class ConverterDDL
    {
        public static DataRow CreateRow(char Value, string Text, DataTable dt)
        {

            // Create a DataRow using the DataTable defined in the 
            // CreateDataSource method.
            DataRow dr = dt.NewRow();

            // This DataRow contains the ColorTextField and ColorValueField 
            // fields, as defined in the CreateDataSource method. Set the 
            // fields with the appropriate value. Remember that column 0 
            // is defined as ColorTextField, and column 1 is defined as 
            // ColorValueField.
            dr[1] = Text;
            dr[0] = Value;

            return dr;

        }
        public static DataRow CreateRow(int Value, string Text, DataTable dt)
        {

            // Create a DataRow using the DataTable defined in the 
            // CreateDataSource method.
            DataRow dr = dt.NewRow();

            // This DataRow contains the ColorTextField and ColorValueField 
            // fields, as defined in the CreateDataSource method. Set the 
            // fields with the appropriate value. Remember that column 0 
            // is defined as ColorTextField, and column 1 is defined as 
            // ColorValueField.
            dr[1] = Text;
            dr[0] = Value;

            return dr;

        }
    }
}
