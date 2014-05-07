using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class PageHandler
    {

        private Page PageList;

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
                        // add all id lines to page
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
                        else if ((newEntry.compareTo(temp) < 0) && (newEntry.compareTo(temp.getNext()) < 0))
                        {
                            //add newEntry between 
                            newEntry.setNext(temp);
                            newEntry.setPrev(temp.getPrev());
                            temp.getPrev().setNext(newEntry);
                            temp.setPrev(newEntry);

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


        public string printPageList()
        {
            return PageList.toString();
        }
    }
}
