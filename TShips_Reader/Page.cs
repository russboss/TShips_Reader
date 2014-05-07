using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Page
    {
        private Page next = null;
        private Page prev = null;
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
            if (getNext() != null)
            {
                return getID() + " " + getTitle() + "\n" + getNext().toString();
            }
            else
            {
                return "";
            }
        }

    }
}
