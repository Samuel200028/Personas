using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using PersonM;
using System.Collections.ObjectModel;
using static PersonVM.MainPerson;
using System.Windows.Forms;

namespace PersonVM
{
    public class MainPerson : ViewModelBase
    {
        //private int num1;
        //private int num2;
        //private int res;
        //private ICommand saveCommand;

        //public int Num1
        //{
        //    get { return num1; }
        //    set
        //    {
        //        if (value == num1)
        //            return;
        //        num1 = value;
        //        Sumar();
        //        OnPropertyChanged("Num1");
        //    }
        //}
        //public int Num2
        //{
        //    get { return num2; }
        //    set
        //    {
        //        if (value == num2)
        //            return;
        //        num2 = value;
        //        Sumar();
        //        OnPropertyChanged("Num2");
        //    }
        //}
        //public int Res
        //{
        //    get { return res; }
        //    set
        //    {
        //        if (value == res)
        //            return;
        //        res = value;
        //        OnPropertyChanged("Res");
        //    }
        //}

        //public ICommand SaveCommand
        //{
        //    get
        //    {
        //        if (saveCommand == null)
        //        {
        //            saveCommand = new RelayCommand(p => this.Save());
        //        }
        //        return saveCommand;
        //    }
        //}

        //public MainPerson()
        //{
        //    Num1 = 15;
        //    Num2 = 30;
        //    Res = 45;
        //}
        //public void Sumar()
        //{
        //    Res = Num1 + Num2;
        //}
        //public void Save()
        //{
        //    //MessageBoxResult mbr = MessageBox.Show("Desea guardarlo?????? ;)", "Advertencia", MessageBoxButton.YesNo);
        //    //if (mbr == MessageBoxResult.Yes)
        //    //{
        //    //    DataAccess da = new DataAccess();
        //    //    Data data = new Data();
        //    //    data.N1 = Num1;
        //    //    data.N2 = Num2;
        //    //    data.R = Res;
        //    //    da.Save(data);
        //    //}

        //}

        private ICommand moverDD, moverD, moverII, moverI;

        public ObservableCollection<Persona> Personas1 { get; set; }
        public ObservableCollection<Persona> Personas2 { get; set; }

        public class Persona
        {
            private int id;
            private string nombre;
            private string correo;

            public int Id
            {
                get { return id; }
                set 
                { 
                    if(id != value)
                    {
                        id = value;
                        //OnPropertyChanged("Id");
                    }
                         
                }
            }

            public string Nombre
            {
                get { return nombre; }
                set
                {
                    if (nombre != value)
                    {
                        nombre = value;
                        //OnPropertyChanged("Nombre");
                    }

                }
            }

            public string Correo
            {
                get { return correo; }
                set
                {
                    if (correo != value)
                    {
                        correo = value;
                        //OnPropertyChanged("Correo");
                    }

                }
            }
        }

        public ICommand MoverDD
        {
            get
            {
                if (moverDD == null)
                {
                    moverDD = new RelayCommand(p => this.movDD());
                }
                return moverDD;
            }
        }

        public ICommand MoverD
        {
            get
            {
                if (moverD == null)
                {
                    moverD = new RelayCommand(p => this.movD());
                }
                return moverD;
            }
        }

        public ICommand MoverI
        {
            get
            {
                if (moverI == null)
                {
                    moverI = new RelayCommand(p => this.movI());
                }
                return moverI;
            }
        }

        public ICommand MoverII
        {
            get
            {
                if (moverII == null)
                {
                    moverII = new RelayCommand(p => this.movII());
                }
                return moverII;
            }
        }

        public void movD()
        {
            if (Personas1.Count > 0)
            {
                Persona ultimo = Personas1[Personas1.Count - 1];
                Personas1.Remove(ultimo);
                Personas2.Add(ultimo);
            }
            else
            {
                MessageBox.Show("No hay datos");
            }
        }
        public void movI()
        {
            if (Personas2.Count > 0)
            {
                Persona ultimo = Personas2[Personas2.Count - 1];
                Personas2.Remove(ultimo);
                Personas1.Add(ultimo);
            }
            else
            {
                MessageBox.Show("No hay datos");
            }
        }

        public void movDD()
        {
            foreach (var persona in Personas1)
            {
                Personas2.Add(persona);
            }
            Personas1.Clear();
        }
        public void movII()
        {
            foreach (var persona in Personas2)
            {
                Personas1.Add(persona);
            }
            Personas2.Clear();
        }

        public MainPerson()
        {
            Personas1 = new ObservableCollection<Persona>();
            Personas2 = new ObservableCollection<Persona>();

            Personas1.Add(new Persona { Id = 1, Nombre = "John Doe", Correo = "johndoe@example.com" });
            Personas1.Add(new Persona { Id = 2, Nombre = "Jane Smith", Correo = "janesmith@example.com" });
            Personas1.Add(new Persona { Id = 3, Nombre = "Bob Johnson", Correo = "bobjohnson@example.com" });

            Personas2.Add(new Persona { Id = 1, Nombre = "John Doe", Correo = "johndoe@example.com" });
            Personas2.Add(new Persona { Id = 2, Nombre = "Jane Smith", Correo = "janesmith@example.com" });
            Personas2.Add(new Persona { Id = 3, Nombre = "Bob Johnson", Correo = "bobjohnson@example.com" });
            Personas2.Add(new Persona { Id = 1, Nombre = "John Doe", Correo = "johndoe@example.com" });
            Personas2.Add(new Persona { Id = 2, Nombre = "Jane Smith", Correo = "janesmith@example.com" });
            Personas2.Add(new Persona { Id = 3, Nombre = "Bob Johnson", Correo = "bobjohnson@example.com" });
        }

    }
}
