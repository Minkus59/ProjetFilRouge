﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Leptitbelgique_Admin.Classes;
using Leptitbelgique_Admin.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Leptitbelgique_Admin.ViewModels
{
    class UtilisateurViewModels : ViewModelBase
    {
        public UtilisateurViewModels()
        {
            Utilisateur = new Utilisateur();
            ListUtilisateurs = new ObservableCollection<Utilisateur>(Utilisateur.GetAll());
            ValidUtilisateur = new RelayCommand(ActionValidUtilisateur);
            AnnulerUtilisateur = new RelayCommand(ActionAnnulerUtilisateur);
            SupprimerUtilisateur = new RelayCommand(ActionSupprimerUtilisateur);

        }

        #region Utilisateur
        private Utilisateur utilisateur;
        private string utilisateurButton;

        public int Id { get => Utilisateur.Id; set => Utilisateur.Id = value; }

        public int Actif
        {
            get
            {
                if (ActifIsOui)
                    return 1;
                else
                    return 0;
            }
        }
        public int Administrateur
        {
            get
            {
                if (AdministrateurIsOui)
                    return 1;
                else
                    return 0;
            }
        }

        public string Nom
        {
            get => Utilisateur.Nom;
            set
            {
                if (Tools.IsText(value))
                {
                    Utilisateur.Nom = value;
                    RaisePropertyChanged("Nom");
                }
                else
                    MessageBox.Show("Le nom ne correspond pas aux critères", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public string Email
        {
            get => Utilisateur.Email;
            set
            {
                if (Tools.IsMail(value))
                {
                    Utilisateur.Email = value;
                    RaisePropertyChanged("Email");
                }
                else
                    MessageBox.Show("L'adresse e-mail ne correspond pas aux critères", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public string MotDePasse
        {
            get => Utilisateur.MotDePasse;
            set
            {
                if (Tools.IsMdp(value))
                {
                    Utilisateur.MotDePasse = value;
                    RaisePropertyChanged("MotDePasse");
                }
                else
                    MessageBox.Show("Le mot de passe ne correspond pas aux critères", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool AdministrateurIsOui
        {
            get => Utilisateur.AdministrateurIsOui;
            set
            {
                Utilisateur.AdministrateurIsOui = value;
                RaisePropertyChanged("AdministrateurIsOui");
            }
        }

        public bool AdministrateurIsNon
        {
            get => Utilisateur.AdministrateurIsNon;
            set
            {
                Utilisateur.AdministrateurIsNon = value;
                RaisePropertyChanged("AdministrateurIsNon");

            }
        }

        public bool ActifIsOui
        {
            get => Utilisateur.ActifIsOui;
            set
            {
                Utilisateur.ActifIsOui = value;
                RaisePropertyChanged("ActifIsOui");
            }
        }

        public bool ActifIsNon
        {
            get => Utilisateur.ActifIsNon;
            set
            {
                Utilisateur.ActifIsNon = value;
                RaisePropertyChanged("ActifIsNon");
            }
        }

        public ObservableCollection<Utilisateur> ListUtilisateurs { get; set; }

        public Utilisateur Utilisateur
        {
            get => utilisateur; 
            set
            {
                utilisateur = value;

                if (utilisateur != null)
                {
                    if (utilisateur.Administrateur == 1)
                    {
                        utilisateur.AdministrateurIsOui = true;
                        RaisePropertyChanged("AdministrateurIsOui");
                    }
                    else if (utilisateur.Administrateur == 0)
                    {
                        utilisateur.AdministrateurIsNon = true;
                        RaisePropertyChanged("AdministrateurIsNon");
                    }
                    else
                    {
                        utilisateur.AdministrateurIsOui = false;
                        utilisateur.AdministrateurIsNon = false;
                    }

                    if (utilisateur.Actif == 1)
                    {
                        utilisateur.ActifIsOui = true;
                        RaisePropertyChanged("ActifIsOui");
                    }
                    else if (utilisateur.Actif == 0)
                    {
                        utilisateur.ActifIsNon = true;
                        RaisePropertyChanged("ActifIsNon");
                    }
                    else
                    {
                        utilisateur.ActifIsOui = false;
                        utilisateur.ActifIsNon = false;
                    }

                    RaisePropertyChanged("Pseudo");
                    RaisePropertyChanged("Nom");
                    RaisePropertyChanged("Prenom");
                    RaisePropertyChanged("Email");
                    RaisePropertyChanged("MotDePasse");
                    RaisePropertyChanged("UtilisateurButton");

                }
            }
        }

        public ICommand ValidUtilisateur { get; set; }
        public ICommand AnnulerUtilisateur { get; set; }
        public ICommand SupprimerUtilisateur { get; set; }
        public string UtilisateurButton { get => Utilisateur.Id > 0 ? "Modifier" : "Ajouter"; }

        public void ActionAnnulerUtilisateur()
        {
            Utilisateur = new Utilisateur();
        }

        public void ActionSupprimerUtilisateur()
        {

            if (Utilisateur.Id > 0)
            {
                MessageBoxResult result = MessageBox.Show("Etes vous sur de vouloir supprimer cette utilisateur ?", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Utilisateur.Administrateur = Administrateur;
                        Utilisateur.Actif = Actif;
                        if (Utilisateur.Delete())
                        {
                            MessageBox.Show("Utilisateur Supprimer");
                            ListUtilisateurs = new ObservableCollection<Utilisateur>(Utilisateur.GetAll());
                            RaisePropertyChanged("ListUtilisateurs");
                            Utilisateur = new Utilisateur();
                        }
                        break;
                    case MessageBoxResult.No:
                        Utilisateur = new Utilisateur();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Aucun Utilisateur selectionné", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ActionValidUtilisateur()
        {
            if (Utilisateur != null)
            {
                if (Utilisateur.Id > 0)
                {
                    Utilisateur.Administrateur = Administrateur;
                    Utilisateur.Actif = Actif;
                    if (Utilisateur.Update())
                    {
                        MessageBox.Show("Utilisateur mis à jour avec l'id " + Utilisateur.Id);
                        ListUtilisateurs = new ObservableCollection<Utilisateur>(Utilisateur.GetAll());
                        RaisePropertyChanged("ListUtilisateurs");
                        Utilisateur = new Utilisateur();
                    }
                }
                else
                {
                    Utilisateur.Administrateur = Administrateur;
                    Utilisateur.Actif = Actif;
                    if (Utilisateur.Add())
                    {
                        MessageBox.Show("Utilisateur ajouté avec l'id :" + Utilisateur.Id);
                        ListUtilisateurs.Add(Utilisateur);
                        Utilisateur = new Utilisateur();
                    }
                    else
                    {
                        MessageBox.Show("Erreur d'ajout", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Erreur d'ajout", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

    }
}