using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Inviticus
{
    public class SharedInformation
    {
        private static SharedInformation instance = new SharedInformation();

        public int babyID { get; set; }

        public BitmapImage bitmapImage { get; private set; }

        public bool IsApplicationInstancePreserved { get; private set; }

        private SharedInformation() { }

        public static SharedInformation getInstance()
        {
            return instance;
        }

        public void saveToIsolatedStorage()
        {
            IsolatedStorageSettings isoStoreSettings = IsolatedStorageSettings.ApplicationSettings;
            isoStoreSettings["IntegerValue"] = babyID;
            IsApplicationInstancePreserved = true;
        }

        public void retrieveFromIsolatedStorage()
        {
            int integerValue;
            IsolatedStorageSettings isoStoreSettings = IsolatedStorageSettings.ApplicationSettings;
            if (isoStoreSettings.TryGetValue("IntegerValue", out integerValue))
            {
                babyID = integerValue;
            }
            isoStoreSettings.Save();
        }

        public void saveBabyPhoto(Stream babyPhoto, string fileName)
        {
            
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(fileName))
                {
                    myIsolatedStorage.DeleteFile(fileName);
                }
                IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(fileName);
                BitmapImage bitmap = new BitmapImage();
                bitmap.SetSource(babyPhoto);
                WriteableBitmap wb = new WriteableBitmap(bitmap);

                // Encode WriteableBitmap object to a JPEG stream.
                Extensions.SaveJpeg(wb, fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                //wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                fileStream.Close();

            }
            
        }

        public BitmapImage getBabyPhoto(string fileName)
        {
            BitmapImage bp = new BitmapImage();
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(fileName, FileMode.Open, FileAccess.Read))
                {
                    bp.SetSource(fileStream);
                }
            }
            return bp;
        }


        public void setBackGroundImage()
        {
            try
            {
                bitmapImage = getBabyPhoto("BackgroundImage");
            }
            catch
            {
                bitmapImage = new BitmapImage(new Uri(@"Assets/Photo0277_edited.jpg", UriKind.Relative));
            }
        }

        public void updateBackground(Stream stream)
        {
            saveBabyPhoto(stream, "BackgroundImage");
            setBackGroundImage();
        }
    }

    
}
