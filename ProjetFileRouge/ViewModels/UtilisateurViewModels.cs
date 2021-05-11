using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjetFileRouge.Classes;
using ProjetFileRouge.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ProjetFileRouge.ViewModels
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

            Canal = new Canal();
            ActiverCanal = new RelayCommand(ActionActiverCanal);
            DesactiverCanal = new RelayCommand(ActionDesactiverCanal);

            Publication = new Publication();
            ActiverPublication = new RelayCommand(ActionActiverPublication);
            DesactiverPublication = new RelayCommand(ActionDesactiverPublication);
            ModifierPublication = new RelayCommand(ActionModifierPublication);
            SupprimerPublication = new RelayCommand(ActionSupprimerPublication);
            AnnulerPublication = new RelayCommand(ActionAnnulerPublication);
        }

        #region Utilisateur
        private Utilisateur utilisateur;
        private string utilisateurButton;
        public string UtilisateurButton { get => Utilisateur.Id > 0 ? "Modifier" : "Ajouter"; }

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
        public string Pseudo
        {
            get => Utilisateur.Pseudo;
            set
            {
                if (Tools.IsPseudo(value))
                {
                    Utilisateur.Pseudo = value;
                    RaisePropertyChanged("Pseudo");
                }
                else
                    MessageBox.Show("Le pseudonyme ne correspond pas aux critères", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public string Prenom
        {
            get => Utilisateur.Prenom;
            set
            {
                if (Tools.IsText(value))
                {
                    Utilisateur.Prenom = value;
                    RaisePropertyChanged("Prenom");
                }
                else
                    MessageBox.Show("Le prénom ne correspond pas aux critères", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
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
                Canal = new Canal();
                Publication = new Publication();

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
                    RaisePropertyChanged("ContentButton");

                    if (utilisateur != null)
                    {
                        if (utilisateur.Id > 0)
                        {
                            ListCanaux = new ObservableCollection<Canal>(Canal.Find(utilisateur));
                            RaisePropertyChanged("ListCanaux");
                        }
                    }
                    else
                    {
                        ListCanaux = null;
                        ListPublications = null;
                        RaisePropertyChanged("ListCanaux");
                        RaisePropertyChanged("ListPublications");
                    }
                }
            }
        }

        public ICommand ValidUtilisateur { get; set; }
        public ICommand AnnulerUtilisateur { get; set; }
        public ICommand SupprimerUtilisateur { get; set; }

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

        #region Canal
        private Canal canal;
        public ObservableCollection<Canal> ListCanaux { get; set; }

        public int CanalId
        {
            get => Canal.CanalId;
            set
            {
                Canal.CanalId = value;
                RaisePropertyChanged("CanalId");
            }
        }

        public int CanalActif
        {
            get => Canal.CanalActif;
            set
            {
                Canal.CanalActif = value;
                RaisePropertyChanged("CanalActif");
            }
        }

        public Canal Canal
        {
            get => canal;
            set
            {
                Publication = new Publication();

                canal = value;
                RaisePropertyChanged("Canal");

                if (canal != null)
                {
                    if (canal.CanalId > 0)
                    {
                        ListPublications = new ObservableCollection<Publication>(Publication.Find(canal));
                        RaisePropertyChanged("ListPublications");
                    }
                }
                else
                {
                    ListPublications = null;
                    RaisePropertyChanged("ListPublications");
                }
            }
        }
        public ICommand ActiverCanal { get; set; }
        public ICommand DesactiverCanal { get; set; }

        public void ActionActiverCanal()
        {
            if (Canal != null)
            {
                if (Canal.CanalId > 0)
                {
                    MessageBoxResult result = MessageBox.Show("Etes vous sur de vouloir activer ce canal ?", "Activation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            Canal.CanalActif = 1;
                            if (Canal.Update())
                            {
                                MessageBox.Show("Canal activer");
                                ListCanaux = new ObservableCollection<Canal>(Canal.Find(utilisateur));
                                RaisePropertyChanged("ListCanaux");
                                Canal = new Canal();
                            }
                            break;
                        case MessageBoxResult.No:
                            Canal = new Canal();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Aucun canal selectionné", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Aucun canal selectionné", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ActionDesactiverCanal()
        {
            if (Canal != null)
            {
                if (Canal.CanalId > 0)
                {
                    MessageBoxResult result = MessageBox.Show("Etes vous sur de vouloir desactiver ce canal ?", "Désactivation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            Canal.CanalActif = 0;
                            if (Canal.Update())
                            {
                                MessageBox.Show("Canal Désactivé");
                                ListCanaux = new ObservableCollection<Canal>(Canal.Find(utilisateur));
                                RaisePropertyChanged("ListCanaux");
                                Canal = new Canal();
                            }
                            break;
                        case MessageBoxResult.No:
                            Canal = new Canal();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Aucun canal selectionné", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Aucun canal selectionné", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Publication
        private Publication publication;
        public ObservableCollection<Publication> ListPublications { get; set; }

        public Publication Publication
        {
            get => publication;
            set
            {
                publication = value;

                RaisePropertyChanged("PublicationActif");
                RaisePropertyChanged("Contenu");
            }
        }

        public string Contenu
        {
            //Ternaire
            get => publication != null ? publication.Contenu : null;
            set
            {
                publication.Contenu = value;

                RaisePropertyChanged("Contenu");
            }
        }

        public int PublicationActif
        {
            get => publication.PublicationActif;
            set
            {
                publication.PublicationActif = value;
                RaisePropertyChanged("PublicationActif");
            }
        }

        public ICommand ActiverPublication { get; set; }
        public ICommand DesactiverPublication { get; set; }
        public ICommand ModifierPublication { get; set; }
        public ICommand AnnulerPublication { get; set; }
        public ICommand SupprimerPublication { get; set; }

        public void ActionActiverPublication()
        {
            if (Publication != null)
            {
                if (Publication.PublicationId > 0)
                {
                    MessageBoxResult result = MessageBox.Show("Etes vous sur de vouloir activer cette publication ?", "Activation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            Publication.PublicationActif = 1;
                            if (Publication.Update())
                            {
                                MessageBox.Show("Publication activé");
                                ListPublications = new ObservableCollection<Publication>(Publication.Find(canal));
                                RaisePropertyChanged("ListPublications");
                                Publication = new Publication();
                            }
                            break;
                        case MessageBoxResult.No:
                            Publication = new Publication();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Aucune publication selectionné", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Aucune publication selectionné", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ActionDesactiverPublication()
        {
            if (Publication != null)
            {
                if (Publication.PublicationId > 0)
                {
                    MessageBoxResult result = MessageBox.Show("Etes vous sur de vouloir désactiver cette publication ?", "Désactivation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    switch (result)
                    {
                        case MessageBoxResult.Yes:

                            Publication.PublicationActif = 0;
                            if (Publication.Update())
                            {
                                MessageBox.Show("Publication Désactivé");
                                ListPublications = new ObservableCollection<Publication>(Publication.Find(canal));
                                RaisePropertyChanged("ListPublications");
                                Canal = new Canal();
                            }
                            break;
                        case MessageBoxResult.No:
                            Canal = new Canal();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Aucune publication selectionné", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Aucune publication selectionné", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ActionAnnulerPublication()
        {
            Publication = new Publication();
        }

        public void ActionSupprimerPublication()
        {

            if (Publication.PublicationId > 0)
            {
                MessageBoxResult result = MessageBox.Show("Etes vous sur de vouloir supprimer cette publication ?", "Suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

                switch (result)
                {
                    case MessageBoxResult.Yes:

                        if (Publication.Delete())
                        {
                            MessageBox.Show("Publication Supprimer");
                            ListPublications = new ObservableCollection<Publication>(Publication.Find(canal));
                            RaisePropertyChanged("ListPublications");
                            Publication = new Publication();
                        }
                        break;
                    case MessageBoxResult.No:
                        Publication = new Publication();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Aucune publication selectionné", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ActionModifierPublication()
        {
            if (Publication != null)
            {
                if (Publication.PublicationId > 0)
                {
                    if (Publication.UpdatePublication(Publication))
                    {
                        MessageBox.Show("Publication mis à jour avec l'id " + Publication.PublicationId);
                        ListPublications = new ObservableCollection<Publication>(Publication.Find(canal));
                        RaisePropertyChanged("ListPublications");
                        Publication = new Publication();
                    }
                }
                else
                {
                    MessageBox.Show("Aucune publication selectionnée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
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