﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Data
    {

        private int ID;
        private String DataLine;

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
            return getID().CompareTo(B.getID());
        }

    }
}
