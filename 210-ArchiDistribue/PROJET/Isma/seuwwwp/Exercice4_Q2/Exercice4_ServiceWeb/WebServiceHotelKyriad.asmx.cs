﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Exercice4_Console;

namespace Exercice4_ServiceWeb
{
    /// <summary>
    /// Description résumée de WebService3
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService3 : System.Web.Services.WebService
    {
        private static Hotel hotelKyriad;
        private static List<Offer> listAllOffres;
        private string login = "kyriad";
        private string password = "kyriad";
        private static bool isAuth = false;
        private static bool isOfferExist = false;

        [WebMethod]
        public bool Authentification(string login, string password)
        {
            if (login.Equals(this.login) && password.Equals(this.password))
            {
                isAuth = true;

                if (hotelKyriad == null || listAllOffres == null)
                {
                    this.CreateHotelAndGenerateOffers();
                }

                return isAuth;
            }
            else
            {
                isAuth = false;
                return isAuth;
            }
        }

        [WebMethod]
        public string GetListeOffre(string dateDebut, string dateFin, int nombrePersonne)
        {
            if (isAuth)
            {
                string listOffers = "";

                for (int i = 0; i < listAllOffres.Count; i++)
                {
                    if (listAllOffres.ElementAt(i).Disponible)
                    {
                        if (nombrePersonne <= listAllOffres.ElementAt(i).Chambre.NombrePersonne)
                        {
                            Offer offer = listAllOffres.ElementAt(i);
                            listOffers = listOffers
                                         + offer.IdOffre
                                         + "=" + offer.DateDisponibilite
                                         + "=" + offer.Chambre.NumeroChambre
                                         + "=" + offer.Chambre.NombreLit
                                         + "=" + offer.PrixOffre
                                         + "=" + offer.ImageChambreURL
                                         + "@";
                        }
                    }
                }

                return listOffers;
            }

            return null;
        }

        [WebMethod]
        public string VerifyOffer(string idOffer)
        {
            for (int i = 0; i < listAllOffres.Count; i++)
            {
                Offer offer = listAllOffres.ElementAt(i);

                if (offer.IdOffre.Equals(idOffer) && offer.Disponible)
                {
                    isOfferExist = true;
                    return offer.IdOffre
                           + "=" + offer.DateDisponibilite
                           + "=" + offer.Chambre.NumeroChambre
                           + "=" + offer.Chambre.NombreLit
                           + "=" + offer.PrixOffre
                           + "=" + offer.ImageChambreURL;
                }
            }

            isOfferExist = false;
            return "Cette offre n'est pas disponible, veuillez consulter la liste des offres";
        }

        [WebMethod]
        public string BookingRegistration(string idOffre, Client client)
        {
            if (isOfferExist)
            {
                for (int i = 0; i < listAllOffres.Count; i++)
                {
                    if (listAllOffres.ElementAt(i).IdOffre.Equals(idOffre))
                        listAllOffres.ElementAt(i).Disponible = false;
                }
                return "----- Réservation effectué avec sucées -----".ToUpper();
            }

            return null;
        }

        public void CreateHotelAndGenerateOffers()
        {
            Chambre chambre1 = new Chambre(2, 2, 300, "https://www.usine-digitale.fr/mediatheque/3/9/8/000493893_homePageUne/hotel-c-o-q-paris.jpg");
            Chambre chambre2 = new Chambre(3, 2, 400, "https://d397xw3titc834.cloudfront.net/images/original/2/b8/2b8e013e6c5fb747415b8a916eff7eb7.jpg");
            Chambre chambre3 = new Chambre(5, 5, 800, "https://media-cdn.tripadvisor.com/media/photo-s/06/b8/de/88/l-azur-hotel-restaurant.jpg");
            Chambre chambre4 = new Chambre(3, 3, 500, "https://lemistral.eu/wp-content/uploads/quintuple/chambre-quintuple-chambre-3-lits-768x432.jpg");
            Chambre chambre5 = new Chambre(2, 1, 250, "https://static.dayuse.com/blog/2017/06/23131632/26-06-2017-Dayuse-Experience-Deco-5-ide%CC%81es-pour-ame%CC%81nager-sa-chambre-comme-a%CC%80-lho%CC%82tel-La-belle-juliette.jpg");
            Chambre chambre6 = new Chambre(4, 4, 700, "https://www.efteling.com/fr/-/media/images/nieuw-overnachten/loonsche-land/hotel/1024x576-loonsche-land-hotel-kamer-5p-imagegallerij.jpg");
            Chambre chambre7 = new Chambre(3, 1, 350, "https://resize-elle.ladmedia.fr/rcrop/638,,forcex/img/var/plain_site/storage/images/deco/pieces/chambre/voila-comment-faire-un-lit-comme-dans-un-hotel-5-etoiles/faire-son-lit-facon-couture/88674953-1-fre-FR/Faire-son-lit-facon-couture.jpg");
            Chambre chambre8 = new Chambre(4, 2, 300, "https://media-cdn.tripadvisor.com/media/photo-s/03/d4/df/54/chambre-classique-2-lits.jpg");
            Chambre chambre9 = new Chambre(4, 3, 650, "https://www.hotel-thalie.com/images/rooms/items/images/4-uUd5970gjk.jpg");
            Chambre chambre10 = new Chambre(5, 4, 750, "https://d397xw3titc834.cloudfront.net/images/original/2/31/231d85a09fb1959145b71f1408345f10.jpg");
            Chambre chambre11 = new Chambre(5, 3, 700, "https://media-cdn.tripadvisor.com/media/photo-s/06/28/8c/9f/balladins-sarcelles.jpg");
            Chambre chambre12 = new Chambre(2, 1, 270, "https://assets.hotelaparis.com/uploads/pictures/000/043/953/Chambre-3-6.jpg");
            Chambre chambre13 = new Chambre(1, 1, 250, "https://media-cdn.tripadvisor.com/media/photo-s/09/75/9f/d5/mariafe-inn.jpg");
            Chambre chambre14 = new Chambre(1, 1, 290, "https://www.yonder.fr/sites/default/files/styles/scale_1008x672/public/destinations/B-HOTEL%20SQUARE%20LOUVOIS%20-%20Chambre%20Classique%2001.jpg?itok=_vc88Bdp");
            Chambre chambre15 = new Chambre(2, 2, 360, "https://www.vendee-hotel-restaurant.com/wp-content/uploads/2014/10/IMG_9063-700x467.jpg");

            List<Chambre> listChambre = new List<Chambre>();
            listChambre.Add(chambre1);
            listChambre.Add(chambre2);
            listChambre.Add(chambre3);
            listChambre.Add(chambre4);
            listChambre.Add(chambre5);
            listChambre.Add(chambre6);
            listChambre.Add(chambre7);
            listChambre.Add(chambre8);
            listChambre.Add(chambre9);
            listChambre.Add(chambre10);
            listChambre.Add(chambre11);
            listChambre.Add(chambre12);
            listChambre.Add(chambre13);
            listChambre.Add(chambre14);
            listChambre.Add(chambre15);

            hotelKyriad = new Hotel("Hotel Laperonie",
                                         "France",
                                         "Montpellier",
                                         "570 Route de Ganges",
                                         "Kyriad",
                                         "1654:4862:120",
                                         5, listChambre);

            listAllOffres = new List<Offer>();

            for (int i = 0; i < hotelKyriad.ListeChambre.Count; i++)
            {
                Offer offer = new Offer();

                if (i < 10)
                    offer = new Offer("Offre#" + (i + 1), hotelKyriad.ListeChambre.ElementAt(i), "2020-03-0" + (i + 1), hotelKyriad.ListeChambre.ElementAt(i).PrixChambre - 20, hotelKyriad.ListeChambre.ElementAt(i).ImageURL, true);
                else
                    offer = new Offer("Offre#" + (i + 1), hotelKyriad.ListeChambre.ElementAt(i), "2020-03-" + (i + 1), hotelKyriad.ListeChambre.ElementAt(i).PrixChambre - 20, hotelKyriad.ListeChambre.ElementAt(i).ImageURL, true);

                listAllOffres.Add(offer);
            }
        }
    }
}
