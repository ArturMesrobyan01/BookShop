using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace BookShop.Models
{
    public class BooksJsonCreater
    {
        private static BooksJsonCreater _item = null;
        private static object _padlock = new object();

        private  BooksJsonCreater(){ }
        public static BooksJsonCreater ItemGetter()
        {
            lock (_padlock)
            {
                if (_item == null)
                {
                    _item = new BooksJsonCreater();
                }
                return _item;
            }  
        }

        //Need here make methods async?
        public async Task<IList<Book>> GetBooks()
        {

            FileStream file = new FileStream(@"C:\Users\Artur.Mesrobyan\Desktop\Projects\BookShop\BookShop\data\books.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            byte[] arr = new byte[file.Length];
            file.Read(arr);
            file.Close();
            string json = Encoding.UTF8.GetString(arr);

           
           return JsonConvert.DeserializeObject<List<Book>>(json);
        }

        public async Task SetBooks(IList<Book> books)
        {
            string booksJson = JsonConvert.SerializeObject(books);
            byte[] arr = Encoding.UTF8.GetBytes(booksJson);
            FileStream file = new FileStream(@"C:\Users\Artur.Mesrobyan\Desktop\Projects\BookShop\BookShop\data\books.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            file.Write(arr);
            file.Close();
        }

    }
}
