using Inviticus.Model;
using Inviticus.Model.DataContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<WHOChildGrowthStandards> childGrowth { get; set; }

        public GetWHOChildGrowthStandards growthStandardards = new GetWHOChildGrowthStandards();

        public ObservableCollection<Weight> p10 { get; set; }

        public ObservableCollection<Weight> p50 { get; set; }

        public ObservableCollection<Weight> p75 { get; set; }

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
		
		
		 public void deleteBabyPhoto(string fileName)
        {

            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(fileName))
                {
                    myIsolatedStorage.DeleteFile(fileName);
                }

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
                SolidColorBrush blueBrush = new SolidColorBrush(Colors.Cyan);
            }
        }

        public void updateBackground(Stream stream)
        {
            saveBabyPhoto(stream, "BackgroundImage");
            setBackGroundImage();
        }

        public void getWHOChildGrowthStandards(string json)
        {
            this.childGrowth = growthStandardards.DataElements(json);
        }

        public void computeWHOGrowthStandards(Baby baby, int index)
        {
            ObservableCollection<Weight> p10List = new ObservableCollection<Weight>();
            ObservableCollection<Weight> p50List = new ObservableCollection<Weight>();
            ObservableCollection<Weight> p75List = new ObservableCollection<Weight>();
            int i = 0;
            foreach (WHOChildGrowthStandards child in this.childGrowth)
            {
                i++;
                Weight weight = new Weight();
                Weight weight2 = new Weight();
                Weight weight3 = new Weight();
                DateTime dt = Convert.ToDateTime(baby.BirthDate).AddMonths(child.Month);
                String date = (dt.Month + "/" + dt.Day + "/" + dt.Year).ToString();
                weight.Date = date;
                weight.BabyWeight = (child.P10).ToString();
                p10List.Add(weight);

                weight2.Date = date;
                weight2.BabyWeight = (child.P50).ToString();
                p50List.Add(weight2);

                weight3.Date = date;
                weight3.BabyWeight = (child.P75).ToString();
                p75List.Add(weight3);

                if (i == index) break;
            }

            this.p10 = p10List;
            this.p50 = p50List;
            this.p75 = p75List;
        }
    }

    public class WeightInfo
    {
        public String Date { get; set; }
        public String BabyWeight { get; set; }
    }
}
