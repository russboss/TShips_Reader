using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Data : IComparable<Data>
    {

        private String DataLine;
        private int ID;

        public Data(int newID, String newDataLine)
        {
            ID = newID;
            DataLine = newDataLine;
        }
        public int getID()
        {
            return ID;
        }
        public String getData()
        {
            return DataLine;
        }
        public void replaceData(Data B)
        {
            DataLine = B.getData();
        }
        public int CompareTo(Data B)
        {
            if (B == null)
            {
                return 1;
            }

            Data otherData = B as Data;
            if (this.getID() < otherData.getID())
            {
                return -1;
            }
            else if (this.getID() > otherData.getID())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }




    }
}
