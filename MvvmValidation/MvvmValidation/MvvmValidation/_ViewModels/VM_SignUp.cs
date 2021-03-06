﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MvvmValidation
{
    public class VM_SignUp: INotifyPropertyChanged
    {
        private string lblNombreUsuario ="Introduce tu nombre de usuario";
        private string lblContraseña = "Introduce tu contraseña";
        private string mensaje ="No se permiten cacteres especiales";
        private string enUsuario;
        private string enContraseña;
        private bool ispassword = true;
        private bool isEnable;
        private bool visible;
        private string mesajebutton="Mostrar contraseña";

        public  VM_SignUp()
        {
            Clicked = new Command(ShowPass);
        }

        private void ShowPass(object obj)
        {
            Password = (Password == true) ? Password = false:Password=true;
        }

        public Command Clicked{ get; }

        public string MensajeButton
        {
            get { return mesajebutton; }
            set { mesajebutton = value; }
        }

        public bool IsVisible
        {
            get { return visible; }
            set { visible = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Mensaje));
            }
        }


        public bool IsEnable
        {
            get { return isEnable; }
            set { isEnable = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Mensaje));
            }
        }

        public bool Password
        {
            get { return ispassword; }
            set { ispassword = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Mensaje));
            }
        }

        public string LblContraseña
        {
            get { return lblContraseña; }
            set { lblContraseña = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Mensaje));
            }
        }

        public string LblUsuario
        {
            get { return lblNombreUsuario; }
            set {
                lblNombreUsuario = value;
            }
        }

        public string EnUsuario
        {
            get { return enUsuario; }
            set {
                enUsuario = value;
                if (enUsuario.Contains("=") || enUsuario.Contains("'") || enUsuario.Contains("?")
                    || enUsuario.Contains("/") || enUsuario.Contains("$") || enUsuario.Contains("#")
                    || enUsuario.Contains("|") || enUsuario.Contains(" "))
                {
                    IsVisible = true;
                    IsEnable = false;
                }
                else
                {
                    IsVisible = false;
                    IsEnable = true;
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(Mensaje));
            }
        }

        public string EnContraseña
        {
            get { return enContraseña; }
            set { enContraseña = value; }
        }


        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
