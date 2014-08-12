using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inviticus.Model;
using Inviticus.ViewModels;

namespace Inviticus
{
    public class ComputeImmunization
    {
        SharedInformation info = SharedInformation.getInstance();

        private static ComputeImmunization instance = new ComputeImmunization();

        private ComputeImmunization() { }

        public static ComputeImmunization getInstance()
        {
            return instance;
        }

        public string [] Vaccine = { "BCG Immunization", "Polio 0", "Polio 1", "DPT-HebB+Hib 1", "Polio 2", "DPT-HebB+Hib 2", "Polio 3", "DPT-HebB+Hib 3", "Measles"};

        public void computeImmunizationData(DateTime date) 
        {
     
            BabyViewModel _babyViewModel = new BabyViewModel(info.babyID);
            foreach (string vaccine in Vaccine)
            {
                _babyViewModel.InitializeNewImmunisationData();
                switch (vaccine)
                {
                    case "BCG Immunization":
                        _babyViewModel.NewImmunisationData.Immunisation = vaccine;
                        _babyViewModel.NewImmunisationData.ImmunisationDetails = "the BCG vaccine is given against Tuberculosis, it is given at birth and is given on the right upper arm";
                        _babyViewModel.NewImmunisationData.Date = date.ToString("d");
                        _babyViewModel.NewImmunisationData.ImmunisationPeriod = "Given At Birth";

                        break;
                    case "Polio 0":
                        _babyViewModel.NewImmunisationData.Immunisation = vaccine;
                        _babyViewModel.NewImmunisationData.ImmunisationDetails = "The Polio Vaccine is given against Polio, the first of 4 doses and is administered through mouth drops";
                        _babyViewModel.NewImmunisationData.Date = date.ToString("d");
                        _babyViewModel.NewImmunisationData.ImmunisationPeriod = "Given At Birth";

                        break;
                    case "Polio 1":
                        _babyViewModel.NewImmunisationData.Immunisation = vaccine;
                        _babyViewModel.NewImmunisationData.ImmunisationDetails = "The Polio 1 Vaccine is given against Polio, it is the first of four doses and as is the nature with polio vaccines administered through mouth drops ";
                        _babyViewModel.NewImmunisationData.Date = date.AddDays(42).ToString("d");
                        _babyViewModel.NewImmunisationData.ImmunisationPeriod = "Given At 6 Weeks";

                        break;
                    case "DPT-HebB+Hib 1":
                        _babyViewModel.NewImmunisationData.Immunisation = vaccine;
                        _babyViewModel.NewImmunisationData.ImmunisationDetails = "The DPT-HebB+Hib 1 Vaccine is against a composition of diseases, Diphtheria, Tetanus, Whooping Cough, Hepatitis B, Haemophilus Influenza type B, it is the first of 3 doses and is administered on the left upper thigh";
                        _babyViewModel.NewImmunisationData.Date = date.AddDays(42).ToString("d");
                        _babyViewModel.NewImmunisationData.ImmunisationPeriod = "Given At 6 Weeks";

                        break;
                    case "Polio 2":
                        _babyViewModel.NewImmunisationData.Immunisation = vaccine;
                        _babyViewModel.NewImmunisationData.ImmunisationDetails = "The Polio 2 Vaccine is given against Polio, it is the second of four doses and is administered through mouth drops";
                        _babyViewModel.NewImmunisationData.Date = date.AddDays(70).ToString("d");
                        _babyViewModel.NewImmunisationData.ImmunisationPeriod = "Given At 10 Weeks";

                        break;
                    case "DPT-HebB+Hib 2":
                        _babyViewModel.NewImmunisationData.Immunisation = vaccine;
                        _babyViewModel.NewImmunisationData.ImmunisationDetails = "The DPT-HebB+Hib 2 Vaccine is against a composition of diseases, Diphtheria, Tetanus, Whooping Cough, Hepatitis B, Haemophilus Influenza type B, it is the second of 3 doses and is administered on the left upper thigh";
                        _babyViewModel.NewImmunisationData.Date = date.AddDays(70).ToString("d");
                        _babyViewModel.NewImmunisationData.ImmunisationPeriod = "Given At 10 Weeks";

                        break;
                    case "Polio 3":
                        _babyViewModel.NewImmunisationData.Immunisation = vaccine;
                        _babyViewModel.NewImmunisationData.ImmunisationDetails = "The Polio 3 Vaccine is given against Polio, it is the third of four doses and is administered through mouth drops";
                        _babyViewModel.NewImmunisationData.Date = date.AddDays(98).ToString("d");
                        _babyViewModel.NewImmunisationData.ImmunisationPeriod = "Given At 14 Weeks";

                        break;
                    case "DPT-HebB+Hib 3":
                        _babyViewModel.NewImmunisationData.Immunisation = vaccine;
                        _babyViewModel.NewImmunisationData.ImmunisationDetails = "The DPT-HebB+Hib 3 Vaccine is against a composition of diseases, Diphtheria, Tetanus, Whooping Cough, Hepatitis B, Haemophilus Influenza type B, it is the last of the 3 doses and is administered on the left upper thigh";
                        _babyViewModel.NewImmunisationData.Date = date.AddDays(98).ToString("d");
                        _babyViewModel.NewImmunisationData.ImmunisationPeriod = "Given At 14 Weeks";

                        break;
                    case "Measles":
                        _babyViewModel.NewImmunisationData.Immunisation = vaccine;
                        _babyViewModel.NewImmunisationData.ImmunisationDetails = "The Measles vaccine is given against the Measles disease, it is the last vaccine received and is administered on the left upper arm";
                        _babyViewModel.NewImmunisationData.Date = date.AddDays(273).ToString("d");
                        _babyViewModel.NewImmunisationData.ImmunisationPeriod = "Given At 9 months";

                        break;
                    default:
                        break;
                }
                _babyViewModel.AddNewImmunisationData();
            }  			
        }
    }

}
