using HospitalAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAutomation.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Country.Any())
            {
                return;
            }
            var countries = new Country[]
            {
                new Country{ Name ="Turkey", PhoneCode =90},
                new Country{ Name ="Germany", PhoneCode =1},
                new Country{ Name ="United State", PhoneCode =43},
                new Country{ Name ="England", PhoneCode =77},
            };
            context.Country.AddRange(countries);
            context.SaveChanges();


            var cities = new City[]
           {
                 new City{ Name="İstanbul",PlateCode =34,PhoneCode=212 , CountryId =1},
                 new City{ Name="Karabük",PlateCode =78,PhoneCode=370 , CountryId =1},
                 new City{ Name="Sakarya",PlateCode =54,PhoneCode=260 , CountryId =1},
                 new City{ Name="London",PlateCode =22,PhoneCode=326 , CountryId =4},
                 new City{ Name="Manchester",PlateCode =29,PhoneCode=3296 , CountryId =4},
                 new City{ Name="Koln",PlateCode =2,PhoneCode=123 , CountryId =2},
                 new City{ Name="Munich",PlateCode =39,PhoneCode=13 , CountryId =2},
                 new City{ Name="San Jose",PlateCode =12,PhoneCode=43 , CountryId =3},
                 new City{ Name="New York",PlateCode =98,PhoneCode=332 , CountryId =3},
           };
            context.City.AddRange(cities);
            context.SaveChanges();


            var districts = new District[]
            {
                new District{ Name="Merkez" , PhoneCode = 370 , CityId =2},
                new District{ Name="Eskipazar" , PhoneCode = 818 , CityId =2},
                new District{ Name="Kadıköy" , PhoneCode = 212 , CityId =1},
                new District{ Name="Esenyurt" , PhoneCode = 212 , CityId =1},
                new District{ Name="Adapazarı" , PhoneCode = 261 , CityId =3},
                new District{ Name="Serdivan" , PhoneCode = 262 , CityId =3},

                new District{ Name="Acton" , PhoneCode = 2122 , CityId =4},
                new District{ Name="Balham" , PhoneCode = 2331 , CityId =4},
                new District{ Name="Salford" , PhoneCode = 231 , CityId =5},
                new District{ Name="Urmston" , PhoneCode = 331 , CityId =5},

                new District{ Name="Ehrenfeld" , PhoneCode = 34 , CityId =6},
                new District{ Name="Lindenthal" , PhoneCode = 3 , CityId =6},
                new District{ Name="Pullach" , PhoneCode = 1 , CityId =7},
                new District{ Name="Sauerlach" , PhoneCode = 11 , CityId =7},

                new District{ Name="Whitesand" , PhoneCode = 21 , CityId =8},
                new District{ Name="Calview" , PhoneCode = 31 , CityId =8},
                new District{ Name="1st" , PhoneCode = 76 , CityId =9},
                new District{ Name="2nd" , PhoneCode = 78 , CityId =9},


            };
            context.District.AddRange(districts);
            context.SaveChanges();


            var hospitals = new Hospital[]
            {
                new Hospital { Name="Karabük Devlet Hastanesi" , PhoneNumber="23123123123", DistrictId=1 },
                new Hospital { Name="Eskipazar Devlet Hastanesi" , PhoneNumber="23123123123", DistrictId=2 },
                new Hospital { Name="Acıbadem Hastanesi" , PhoneNumber="23123123123", DistrictId=3 },
                new Hospital { Name="Esenyurt Devlet Hastanesi" , PhoneNumber="23123123123", DistrictId=4 },
                new Hospital { Name="Adapazarı Devlet Hastanesi" , PhoneNumber="23123123123", DistrictId=5 },
                new Hospital { Name="Serdivan Sabancı Hastanesi" , PhoneNumber="23123123123", DistrictId=6 },
                new Hospital { Name="San Jose of Hospital" , PhoneNumber="23123123123", DistrictId=7 },
                new Hospital { Name="Central Hospital" , PhoneNumber="23123123123", DistrictId=8 },
                new Hospital { Name="England Of Hospital" , PhoneNumber="23123123123", DistrictId=9 },
                new Hospital { Name="Soldiers Hospital" , PhoneNumber="23123123123", DistrictId=10 },
            };
            context.Hospital.AddRange(hospitals);
            context.SaveChanges();

            var clinics = new Clinic[]
            {
                new Clinic {Name="Cardiology"},
                new Clinic {Name="Denstistry"},
                new Clinic {Name="Dermatology"},
                new Clinic {Name="Ear,Nose And Throat"},
                new Clinic {Name="Gastroenterology"},
                new Clinic {Name="Gynecology and Obstetrics"},
                new Clinic {Name="Ophthalmology"},
                new Clinic {Name="Orthopedics"},
                new Clinic {Name="Physical Therapy"},
                new Clinic {Name="Podiatry"},
                new Clinic {Name="Urology"},

              };
            context.Clinic.AddRange(clinics);
            context.SaveChanges();

            var hospitalAndClinic = new HospitalAndClinic[]
            {
                new HospitalAndClinic{HospitalId=1,ClinicId=1},
                new HospitalAndClinic{HospitalId=1,ClinicId=2},
                new HospitalAndClinic{HospitalId=1,ClinicId=3},
                new HospitalAndClinic{HospitalId=1,ClinicId=4},
                new HospitalAndClinic{HospitalId=1,ClinicId=5},
                new HospitalAndClinic{HospitalId=1,ClinicId=6},
                new HospitalAndClinic{HospitalId=1,ClinicId=7},
                new HospitalAndClinic{HospitalId=1,ClinicId=8},
                new HospitalAndClinic{HospitalId=1,ClinicId=9},
                new HospitalAndClinic{HospitalId=2,ClinicId=1},
                new HospitalAndClinic{HospitalId=2,ClinicId=2},
                new HospitalAndClinic{HospitalId=2,ClinicId=3},
                new HospitalAndClinic{HospitalId=2,ClinicId=4},
                new HospitalAndClinic{HospitalId=2,ClinicId=5},
                new HospitalAndClinic{HospitalId=2,ClinicId=6},
                new HospitalAndClinic{HospitalId=2,ClinicId=7},
                new HospitalAndClinic{HospitalId=2,ClinicId=8},
                new HospitalAndClinic{HospitalId=2,ClinicId=9},
                new HospitalAndClinic{HospitalId=3,ClinicId=1},
                new HospitalAndClinic{HospitalId=3,ClinicId=2},
                new HospitalAndClinic{HospitalId=3,ClinicId=3},
                new HospitalAndClinic{HospitalId=3,ClinicId=4},
                new HospitalAndClinic{HospitalId=3,ClinicId=5},
                new HospitalAndClinic{HospitalId=4,ClinicId=1},
                new HospitalAndClinic{HospitalId=4,ClinicId=2},
                new HospitalAndClinic{HospitalId=4,ClinicId=3},
                new HospitalAndClinic{HospitalId=4,ClinicId=4},
                new HospitalAndClinic{HospitalId=4,ClinicId=5},
                new HospitalAndClinic{HospitalId=5,ClinicId=1},
                new HospitalAndClinic{HospitalId=5,ClinicId=2},
                new HospitalAndClinic{HospitalId=5,ClinicId=3},
                new HospitalAndClinic{HospitalId=5,ClinicId=4},
                new HospitalAndClinic{HospitalId=5,ClinicId=5},
                new HospitalAndClinic{HospitalId=5,ClinicId=6},
                new HospitalAndClinic{HospitalId=5,ClinicId=7},
                  new HospitalAndClinic{HospitalId=6,ClinicId=1},
                new HospitalAndClinic{HospitalId=6,ClinicId=2},
                new HospitalAndClinic{HospitalId=6,ClinicId=3},
                new HospitalAndClinic{HospitalId=6,ClinicId=4},
                new HospitalAndClinic{HospitalId=6,ClinicId=5},
                new HospitalAndClinic{HospitalId=6,ClinicId=6},
                new HospitalAndClinic{HospitalId=6,ClinicId=7},
                  new HospitalAndClinic{HospitalId=7,ClinicId=1},
                new HospitalAndClinic{HospitalId=7,ClinicId=2},
                new HospitalAndClinic{HospitalId=7,ClinicId=3},
                new HospitalAndClinic{HospitalId=7,ClinicId=4},
                new HospitalAndClinic{HospitalId=7,ClinicId=5},
                new HospitalAndClinic{HospitalId=7,ClinicId=6},
                new HospitalAndClinic{HospitalId=7,ClinicId=7},
                  new HospitalAndClinic{HospitalId=8,ClinicId=1},
                new HospitalAndClinic{HospitalId=8,ClinicId=2},
                new HospitalAndClinic{HospitalId=8,ClinicId=3},
                new HospitalAndClinic{HospitalId=8,ClinicId=4},
                new HospitalAndClinic{HospitalId=8,ClinicId=5},
                new HospitalAndClinic{HospitalId=8,ClinicId=6},
                new HospitalAndClinic{HospitalId=8,ClinicId=7},
                  new HospitalAndClinic{HospitalId=9,ClinicId=1},
                new HospitalAndClinic{HospitalId=9,ClinicId=2},
                new HospitalAndClinic{HospitalId=9,ClinicId=3},
                new HospitalAndClinic{HospitalId=9,ClinicId=4},
                new HospitalAndClinic{HospitalId=9,ClinicId=5},
                new HospitalAndClinic{HospitalId=9,ClinicId=6},
                new HospitalAndClinic{HospitalId=9,ClinicId=7},
                  new HospitalAndClinic{HospitalId=10,ClinicId=1},
                new HospitalAndClinic{HospitalId=10,ClinicId=2},
                new HospitalAndClinic{HospitalId=10,ClinicId=3},
                new HospitalAndClinic{HospitalId=10,ClinicId=4},
                new HospitalAndClinic{HospitalId=10,ClinicId=5},
                new HospitalAndClinic{HospitalId=10,ClinicId=6},
                new HospitalAndClinic{HospitalId=10,ClinicId=7},
            };
            context.HospitalAndClinic.AddRange(hospitalAndClinic);
            context.SaveChanges();

            var doctors = new Doctor[]
            {
                new Doctor{FirstName="Samet",LastName="Ertaş",Adress="Ataturk mahallesi",AdressCity="Karabük",MobileNumber="13123123123",Nationality=1,HomeTown=2,IdentificationNumber="123123123",BirthDate=DateTime.Parse("06-06-1995"),Gender=Models.Enums.Gender.Male,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.APositive,Branch="Dentist",HospitalAndClinicId=1},
                new Doctor{FirstName="Ali",LastName="Ertaş",Adress="Çankaya mahallesi",AdressCity="Ankara",MobileNumber="13123123123",Nationality=1,HomeTown=2,IdentificationNumber="1231123131178923",BirthDate=DateTime.Parse("21-10-1988"),Gender=Models.Enums.Gender.Male,MaritalStatu=Models.Enums.MaritalStatu.Married,BloodType=Models.Enums.BloodType.APositive,Branch="Cardiologist",HospitalAndClinicId=2},
                new Doctor{FirstName="Elif",LastName="Uçar",Adress="Üstükar aşağı sokak",AdressCity="İstanbul",MobileNumber="5435234234",Nationality=1,HomeTown=4,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.ABPositive,Branch="Dermatologist",HospitalAndClinicId=4},
            };
            context.Doctor.AddRange(doctors);
            context.SaveChanges();


            var employees = new Employee[]
          {
                new Employee{FirstName="Hamza",LastName="Yurtal",Adress="Ataturk mahallesi",AdressCity="Karabük",MobileNumber="13123123123",Nationality=1,HomeTown=2,IdentificationNumber="123123123",BirthDate=DateTime.Parse("06-06-1995"),Gender=Models.Enums.Gender.Male,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.APositive,Position="CEO",HospitalAndClinicId=1},
                new Employee{FirstName="Kemal",LastName="Serttaş",Adress="Çankaya mahallesi",AdressCity="Ankara",MobileNumber="13123123123",Nationality=1,HomeTown=2,IdentificationNumber="1231123131178923",BirthDate=DateTime.Parse("21-10-1988"),Gender=Models.Enums.Gender.Male,MaritalStatu=Models.Enums.MaritalStatu.Married,BloodType=Models.Enums.BloodType.APositive,Position="Nurse",HospitalAndClinicId=2},
                new Employee{FirstName="Ugur",LastName="Uçar",Adress="Üstükar aşağı sokak",AdressCity="İstanbul",MobileNumber="5435234234",Nationality=1,HomeTown=3,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Male,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.ABPositive,Position="Nurse",HospitalAndClinicId=4},
                new Employee{FirstName="Sena",LastName="Hızlı",Adress="bakıent yavuz sokak",AdressCity="İstanbul",MobileNumber="5435234234",Nationality=1,HomeTown=1,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.ABPositive,Position="Nurse",HospitalAndClinicId=5},
                new Employee{FirstName="Burcu",LastName="Köle",Adress="Çankaya sokak",AdressCity="İstanbul",MobileNumber="5435234234",Nationality=1,HomeTown=2,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Married,BloodType=Models.Enums.BloodType.ONegative,Position="Nurse",HospitalAndClinicId=4},
                new Employee{FirstName="Ceren",LastName="Yavuz",Adress="Bilkentli Sokak",AdressCity="Sakarya",MobileNumber="5435234234",Nationality=1,HomeTown=3,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.ONegative,Position="Nurse",HospitalAndClinicId=7},
                new Employee{FirstName="Tuğçe",LastName="Karatağ",Adress="Safranbolu esentepe",AdressCity="Ankara",MobileNumber="5435234234",Nationality=1,HomeTown=3,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Dicorved,BloodType=Models.Enums.BloodType.ABPositive,Position="Nurse",HospitalAndClinicId=7},
                new Employee{FirstName="Aslı",LastName="Ünal",Adress="Kadıköy Yıldız sokak",AdressCity="İzmir",MobileNumber="5435234234",Nationality=1,HomeTown=1,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Dicorved,BloodType=Models.Enums.BloodType.ABPositive,Position="Nurse",HospitalAndClinicId=8},
                new Employee{FirstName="Hilal",LastName="Sezer",Adress="İncek mahallesi",AdressCity="İzmir",MobileNumber="5435234234",Nationality=1,HomeTown=2,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.BNegative,Position="Nurse",HospitalAndClinicId=11},
                new Employee{FirstName="Kader",LastName="Yıldız",Adress="Aşti sokak",AdressCity="Eskişehir",MobileNumber="5435234234",Nationality=1,HomeTown=3,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.ABPositive,Position="Nurse",HospitalAndClinicId=11},
                new Employee{FirstName="Hamza",LastName="Sevgili",Adress="Gürses sokak",AdressCity="Karabük",MobileNumber="5435234234",Nationality=1,HomeTown=3,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Male,MaritalStatu=Models.Enums.MaritalStatu.Married,BloodType=Models.Enums.BloodType.BNegative,Position="Nurse",HospitalAndClinicId=12},
                new Employee{FirstName="Deniz",LastName="Yıldırım",Adress="Bayraktar sokak",AdressCity="Zonguldak",MobileNumber="5435234234",Nationality=1,HomeTown=1,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Male,MaritalStatu=Models.Enums.MaritalStatu.Married,BloodType=Models.Enums.BloodType.ABPositive,Position="Nurse",HospitalAndClinicId=7},
          };
            context.Employees.AddRange(employees);
            context.SaveChanges();


            var patients = new Patient[]
         {
                new Patient{FirstName="Hamza",LastName="Yurtal",Adress="Ataturk mahallesi",AdressCity="Karabük",MobileNumber="13123123123",Nationality=1,HomeTown=2,IdentificationNumber="123123123",BirthDate=DateTime.Parse("06-06-1995"),Gender=Models.Enums.Gender.Male,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.APositive},
                new Patient{FirstName="Kemal",LastName="Serttaş",Adress="Çankaya mahallesi",AdressCity="Ankara",MobileNumber="13123123123",Nationality=1,HomeTown=2,IdentificationNumber="1231123131178923",BirthDate=DateTime.Parse("21-10-1988"),Gender=Models.Enums.Gender.Male,MaritalStatu=Models.Enums.MaritalStatu.Married,BloodType=Models.Enums.BloodType.APositive},
                new Patient{FirstName="Ugur",LastName="Uçar",Adress="Üstükar aşağı sokak",AdressCity="İstanbul",MobileNumber="5435234234",Nationality=1,HomeTown=3,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Male,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.ABPositive},
                new Patient{FirstName="Sena",LastName="Hızlı",Adress="bakıent yavuz sokak",AdressCity="İstanbul",MobileNumber="5435234234",Nationality=1,HomeTown=1,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.ABPositive},
                new Patient{FirstName="Burcu",LastName="Köle",Adress="Çankaya sokak",AdressCity="İstanbul",MobileNumber="5435234234",Nationality=1,HomeTown=2,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Married,BloodType=Models.Enums.BloodType.ONegative},
                new Patient{FirstName="Ceren",LastName="Yavuz",Adress="Bilkentli Sokak",AdressCity="Sakarya",MobileNumber="5435234234",Nationality=1,HomeTown=3,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.ONegative},
                new Patient{FirstName="Tuğçe",LastName="Karatağ",Adress="Safranbolu esentepe",AdressCity="Ankara",MobileNumber="5435234234",Nationality=1,HomeTown=3,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Dicorved,BloodType=Models.Enums.BloodType.ABPositive},
                new Patient{FirstName="Aslı",LastName="Ünal",Adress="Kadıköy Yıldız sokak",AdressCity="İzmir",MobileNumber="5435234234",Nationality=1,HomeTown=1,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Dicorved,BloodType=Models.Enums.BloodType.ABPositive},
                new Patient{FirstName="Hilal",LastName="Sezer",Adress="İncek mahallesi",AdressCity="İzmir",MobileNumber="5435234234",Nationality=1,HomeTown=2,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.BNegative},
                new Patient{FirstName="Kader",LastName="Yıldız",Adress="Aşti sokak",AdressCity="Eskişehir",MobileNumber="5435234234",Nationality=1,HomeTown=3,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Female,MaritalStatu=Models.Enums.MaritalStatu.Single,BloodType=Models.Enums.BloodType.ABPositive},
                new Patient{FirstName="Hamza",LastName="Sevgili",Adress="Gürses sokak",AdressCity="Karabük",MobileNumber="5435234234",Nationality=1,HomeTown=3,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Male,MaritalStatu=Models.Enums.MaritalStatu.Married,BloodType=Models.Enums.BloodType.BNegative},
                new Patient{FirstName="Deniz",LastName="Yıldırım",Adress="Bayraktar sokak",AdressCity="Zonguldak",MobileNumber="5435234234",Nationality=1,HomeTown=1,IdentificationNumber="1212313",BirthDate=DateTime.Parse("06-10-1999"),Gender=Models.Enums.Gender.Male,MaritalStatu=Models.Enums.MaritalStatu.Married,BloodType=Models.Enums.BloodType.ABPositive},
         };
            context.Patient.AddRange(patients);
            context.SaveChanges();

            var tests = new Test[]
            {
                new Test {Name="Blood Count"},
                new Test {Name="Hematocrit"},
                new Test {Name="Inulin Clearance"},
                new Test {Name="Serological Test"},
                new Test {Name="Hastric Fluid Analysis"},
                new Test {Name="Protein-Bound Iodine Test"},
                new Test {Name="Toxicology Test"},
                new Test {Name="Skin Test"},
                new Test {Name="Endoscopy"},

            };
            context.Test.AddRange(tests);
            context.SaveChanges();

            var medicines = new Medicine[]
            {
                new Medicine {Name="Aspirin" , Brand = "Abdi Ibrahim ", Price =55 },
                new Medicine {Name="Majezik" , Brand = "Eczacibasi", Price =22},
                new Medicine {Name="Parol " , Brand = "Pzifer", Price =26 },
                new Medicine {Name="CBD" , Brand = "Canabidol", Price =29 },
                new Medicine {Name="Doliprane" , Brand = "Sanofi", Price =67 },
                new Medicine {Name="Aulin" , Brand = "Angelini", Price =99 },
            };
            context.Medicine.AddRange(medicines);
            context.SaveChanges();

            var appointments = new Appointment[]
            {
                new Appointment{Time=DateTime.Parse("21-02-2020 11:30" ),DoctorId=1,PatientId=7,HospitalAndClinicId=12},
                new Appointment{Time=DateTime.Parse("21-03-2020 11:30" ),DoctorId=2,PatientId=12,HospitalAndClinicId=2},
                new Appointment{Time=DateTime.Parse("12-03-2019 11:30" ),DoctorId=2,PatientId=1,HospitalAndClinicId=4},
                new Appointment{Time=DateTime.Parse("02-06-2020 11:30" ),DoctorId=3,PatientId=2,HospitalAndClinicId=7},
                new Appointment{Time=DateTime.Parse("16-08-2018 11:30" ),DoctorId=1,PatientId=4,HospitalAndClinicId=1},
                new Appointment{Time=DateTime.Parse("22-09-2019 11:30" ),DoctorId=3,PatientId=5,HospitalAndClinicId=8},
                new Appointment{Time=DateTime.Parse("28-11-2020 11:30" ),DoctorId=2,PatientId=3,HospitalAndClinicId=9},
            };
            context.Appointment.AddRange(appointments);
            context.SaveChanges();

            var examinations = new Examination[]
            {
                new Examination{Id =1 , Diagnosis="Headache"},
                new Examination{Id =3 , Diagnosis="Nausea"},
                new Examination{Id =5 , Diagnosis="Toothache"},
                new Examination{Id =6 , Diagnosis="Pregnancy"},
                new Examination{Id =4 , Diagnosis="Stabbing"},
                new Examination{Id =2 , Diagnosis="Broken arm"},
                new Examination{Id =7 , Diagnosis="Headache"},
                
            };
            context.Examination.AddRange(examinations);
            context.SaveChanges();

            var examinationAndTests = new ExaminationAndTest[]
           {
                new ExaminationAndTest{ExaminationId=2,TestId=4},
                new ExaminationAndTest{ExaminationId=6,TestId=3},
                new ExaminationAndTest{ExaminationId=1,TestId=1},
                new ExaminationAndTest{ExaminationId=5,TestId=5},
                new ExaminationAndTest{ExaminationId=3,TestId=2},
                new ExaminationAndTest{ExaminationId=7,TestId=6},
          
           };
            context.ExaminationAndTest.AddRange(examinationAndTests);
            context.SaveChanges();

            var prescriptions = new Prescription[]
            {
                new Prescription { Id =1,PrescriptionNumber="d12ds",DateTime=DateTime.Parse("22-07-2020 12:30")},
                new Prescription { Id =3,PrescriptionNumber="f23fd",DateTime=DateTime.Parse("27-05-2020 11:30")},
                new Prescription { Id =5,PrescriptionNumber="f2f23",DateTime=DateTime.Parse("12-04-2020 15:30")},
                new Prescription { Id =7,PrescriptionNumber="2d112",DateTime=DateTime.Parse("09-12-2020 22:30")},
                new Prescription { Id =4,PrescriptionNumber="d1f22",DateTime=DateTime.Parse("04-11-2020 12:45")},
            };
            context.Prescription.AddRange(prescriptions);
            context.SaveChanges();

            var prescriptionAndMedicines = new PrescriptionAndMedicine[]
            {
                new PrescriptionAndMedicine { PrescriptionId=1,MedicineId=1},
                new PrescriptionAndMedicine { PrescriptionId=3,MedicineId=3},
                new PrescriptionAndMedicine { PrescriptionId=1,MedicineId=6},
                new PrescriptionAndMedicine { PrescriptionId=1,MedicineId=1},
                new PrescriptionAndMedicine { PrescriptionId=3,MedicineId=1},
                new PrescriptionAndMedicine { PrescriptionId=3,MedicineId=6},
                new PrescriptionAndMedicine { PrescriptionId=7,MedicineId=5},
                new PrescriptionAndMedicine { PrescriptionId=5,MedicineId=1},
                new PrescriptionAndMedicine { PrescriptionId=4,MedicineId=1},
                new PrescriptionAndMedicine { PrescriptionId=4,MedicineId=4},
            };
            context.PrescriptionAndMedicine.AddRange(prescriptionAndMedicines);
            context.SaveChanges();


        }
    }
}
