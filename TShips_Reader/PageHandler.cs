using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class PageHandler
    {

        private Page PageList;
        /// <summary>
        /// find all pages with matching name
        /// find id on highest PageID first (highest overrides lowest if collision)
        /// </summary>
        /// <param name="pageName">search pageName that describes the object  (ships-> Boardcomp. objects)</param>
        /// <param name="ID">ID that object refers to</param>
        /// <returns>Data entry that is stored in (pageName,ID</returns>
        public string findData(String pageName, int ID ){
            if (PageList != null) {

                Page pageFound = findPage(pageName);
                if (pageFound != null)
                {
                    //lookup data from page
                    return pageFound.getData(ID);
                }
                else
                {
                    //throw PageNotFound error
                    return "";
                }

            } else {
                //throw EmptyPageList error

                return "";
            }
        }

        private Page findPage(string pageSearch)
        {
            Page current = PageList;

            while (current != null)
            {
                if (current.getTitle().CompareTo(pageSearch) == 0)
                {
                    return current;
                }
                else
                {
                    current = current.getNext();
                }
            }            
            return null;
        }



        public Page addPage(int PageId, String title)
        {
            // currently sorted by text
            // should be fewer pages by that
            //possibly seperate list to sort by int to increase search speed?
            Page newEntry = new Page(PageId, title);
            if (PageList == null)
            {
                PageList = newEntry;
            }
            else
            {
                Page temp = PageList;
                while (temp != null)
                {
                    if (newEntry.compareTo(temp) == 0)
                    {
                        // add all id lines to page//store id in Page as list
                        //delete newEntry or set to null
                        newEntry = temp;
                        break;
                    }
                    else
                    {

                        if (temp == PageList && newEntry.compareTo(temp) < 0)
                        {
                            //insert newEntry as new PageList Head and shift old PageList down
                            temp.setPrev(newEntry);
                            newEntry.setNext(temp);
                            PageList = newEntry;
                            break;
                        }
                        else if ( temp.getNext() == null )
                        {
                            temp.setNext(newEntry);
                            newEntry.setPrev(temp);
                            break;
                        }
                        else if ((newEntry.compareTo(temp) > 0) && (newEntry.compareTo(temp.getNext()) < 0))
                        {
                            //add newEntry between 
                            newEntry.setPrev(temp);
                            newEntry.setNext(temp.getNext() );
                            newEntry.getNext().setPrev(newEntry);
                            temp.setNext(newEntry);

                            break;
                        }
                        else
                        {
                            temp = temp.getNext();
                        }
                    }
                }
            }
            return newEntry;
        }//end addPage
        public void addData(int pageId, String pageTitle, int dataId, String newData)
        {
            //find reference to page, based on title
            Page temp = addPage(pageId, pageTitle);
              if (temp != null)
              {
                  temp.addData(dataId,newData);
              }
        }
        //public void 

        public string printPageList()
        {
            return PageList.toString();
        }

        public bool isEmpty()
        {
            if (PageList == null)
            {
                return true;
            }else{
                return false;
            }
        }
    }
}
