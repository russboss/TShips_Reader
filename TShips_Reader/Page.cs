using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace WindowsFormsApplication1
{
    class Page
    {
        private Page next = null;
        private Page prev = null;
        
        //switch List to sth that could allow for easy searching
        private List<Data> DataList = null;
        private String title;
        private int pageId;

        public Page(int newPageId, String newTitle)
        {
            pageId = newPageId;
            title = newTitle;
            DataList = new List<Data>();


        }

        public int getID()
        {
            return pageId;
        }
        public String getTitle()
        {
            return title;
        }
        public int compareTo(Page B)
        {
            if (getTitle().Equals(B.getTitle()))
            {
                return 0;
            }
            else
            {
                return String.Compare(getTitle(), B.getTitle(), StringComparison.OrdinalIgnoreCase);
            }
        }

        public String getData(int dataId){
            //search for data by id
            //return the stored string?
            Data data = DataList.Find(o => o.getID() == dataId);
            //var item = DataList.FirstOrDefault(o => o.GetID() == dataId);
            if (data != null)
            {
                Console.Out.Write("Data Found: " + data);
                return data.getData();
            }
            else
            {
                //throw DataNotFound
                return null;
            }

        }
        public void addData(int newID, String newData)
        {
            Data newDataObj = new Data(newID, newData);

            //if first data item in DataList
            //if should be last item in DataList
            //find location in list
            //  if exist replace with new data(higher page assumed)
            //  if not exist now know where newDataObj should go
            if (DataList.Count == 0)
            {
                DataList.Add(newDataObj);
            }
            else if (DataList[DataList.Count - 1].CompareTo(newDataObj) < 0)
            {
                DataList.Add(newDataObj);
            }
            else
            {
                int index = DataList.BinarySearch(newDataObj);
                if (index < 0)
                {
                    DataList.Insert(~index, newDataObj);
                }
                else
                {
                    DataList[index].replaceData(newDataObj);
                }
            }
        }
        public void setNext(Page newNext)
        {
            next = newNext;
        }
        public Page getNext()
        {
            return next;
        }
        public void setPrev(Page newPrev)
        {
            prev = newPrev;
        }
        public Page getPrev()
        {
            return prev;
        }

        public String toString()
        {
            String str = "";
            if (getNext() != null)
            {
                str = getID() + " " + getTitle() + "\n" + this.getNext().toString();
                return str;
            }
            else
            {
                return "";
            }

        }

    }
}
