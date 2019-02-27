using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Ivo.OefenfirmaCMS.lib.Entities;

namespace Ivo.OefenfirmaCMS.lib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ivo.OefenfirmaCMS.lib.Data.IvoOefenfirmaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Ivo.OefenfirmaCMS.lib.Data.IvoOefenfirmaContext";
        }

        protected override void Seed(Ivo.OefenfirmaCMS.lib.Data.IvoOefenfirmaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Categorieen.AddOrUpdate(c => c.Categorienaam,

                new Categorie { Categorienaam = "Randapparatuur", },
                new Categorie { Categorienaam = "Laptop & PC" },
                new Categorie { Categorienaam = "Servers" },
                new Categorie { Categorienaam = "Netwerk" },
                new Categorie { Categorienaam = "Software" },
                new Categorie { Categorienaam = "Printen/Scannen" },
                new Categorie { Categorienaam = "Componenten" },
                new Categorie { Categorienaam = "Behuizingen", ParentId = 7 },
                new Categorie { Categorienaam = "DVD/Blu Ray", ParentId = 7 },
                new Categorie { Categorienaam = "Geheugen", ParentId = 7 },
                new Categorie { Categorienaam = "Geluidskaarten", ParentId = 7 },
                new Categorie { Categorienaam = "Harde schijven", ParentId = 7 },
                new Categorie { Categorienaam = "Moederborden", ParentId = 7 },
                new Categorie { Categorienaam = "Processoren", ParentId = 7 },
                new Categorie { Categorienaam = "Video & TV-kaarten", ParentId = 7 },
                new Categorie { Categorienaam = "Voedingen", ParentId = 7 },
                new Categorie { Categorienaam = "Tablets", ParentId = 2 },
                new Categorie { Categorienaam = "Apple", ParentId = 2 },
                new Categorie { Categorienaam = "Laptops", ParentId = 2 },
                new Categorie { Categorienaam = "Desktop PC’s", ParentId = 2 },
                new Categorie { Categorienaam = "Routers", ParentId = 4 },
                new Categorie { Categorienaam = "Switchen", ParentId = 4 },
                new Categorie { Categorienaam = "Netwerkkaarten", ParentId = 4 },
                new Categorie { Categorienaam = "Inkjet printers", ParentId = 6 },
                new Categorie { Categorienaam = "Laserprinters", ParentId = 6 },
                new Categorie { Categorienaam = "Scanners", ParentId = 6 },
                new Categorie { Categorienaam = "Externe dataopslag", ParentId = 1 },
                new Categorie { Categorienaam = "Monitoren / Touchscreens", ParentId = 1 },
                new Categorie { Categorienaam = "Speakers / hoofdtelefoons", ParentId = 1 },
                new Categorie { Categorienaam = "Bedieningsapparatuur", ParentId = 1 },
                new Categorie { Categorienaam = "Hewlet Packard", ParentId = 3 },
                new Categorie { Categorienaam = "Supermicro", ParentId = 3 },
                new Categorie { Categorienaam = "Netwerk opslag (NAS)", ParentId = 3 },
                new Categorie { Categorienaam = "Adobe", ParentId = 5 },
                new Categorie { Categorienaam = "Microsoft", ParentId = 5 },
                new Categorie { Categorienaam = "Antivirus", ParentId = 5 }

            );


            //tussentijd bewaren zodat we ZEKER cursussen hebben alvorens ze te selecteren
            //context.SaveChanges();


            //producten randapparatuur

            context.Producten.AddOrUpdate(p => p.Artikelnummer,

                new Product
                {
                    Artikelnummer = "RA-EX-0101",
                    Artikelnaam = "Samsung SE-208DB",
                    Artikelomschrijving =
                        "De SE-208DB/TSBS van Samsung is een Externe DVD-brander, welke via Mini USB wordt aangesloten. De SE-208DB/TSBS " +
                        " kan DVD±R op 8x, DVD±R DL op 6x, DVD+RW op 8x, DVD-RW op 6x, CD-R op 24x, CD-RW op 24x speed kan schrijven" +
                        " en DVD's op 8x, DVD-RAM op 5x, en CD's op 24x speed kan lezen.",
                    FiguurURL = @"Content/images/RA-EX-0101.jpg",
                    Prijs = 28.89M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Externe dataopslag")
                    /*Categorieen.Single(c => c.Categorienaam == "Externe dataopslag")*/
                },
                new Product
                {
                    Artikelnummer = "RA-EX-0102",
                    Artikelnaam = "Transcend JetFlash 500 " +
                                  "\n USB-flashstation",
                    Artikelomschrijving = "Opslagcapaciteit 16 GB, Type interface: USB 2,0" +
                                          " \n Benodigd besturingssysteem: Microsoft Windows 2000, Microsoft Windows Millennium Editie, Apple MacOS 9.0 of" +
                                          " hoger, Microsoft Windows XP, Microsoft Windows 7, Microsoft Windows Vista, Linux Kernel 2.4.2 of hoger",
                    FiguurURL = "",
                    Prijs = 10.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Externe dataopslag")
                },
                new Product
                {
                    Artikelnummer = "RA-MO-0110",
                    Artikelnaam = "Dell UltraSharp U2312HM" +
                                  " LED-monitor",
                    Artikelomschrijving = "23'' - 1920 x 1080 FullHD - IPS - zwart" +
                                          "De Dell UltraSharp U2312HM is een genot voor je ogen.Door de IPS-techniek geniet je van kristalheldere" +
                                          " kleuren en dit is vanuit elke hoek te zien.Met een IPS-scherm blijft het beeld namelijk haarscherp vanuit" +
                                          " elke kijkhoek.De Dell UltraSharp U2312HM beschikt over ruime mogelijkheden voor draaien, kantelen, roteren" +
                                          " en is in de hoogte verstelbaar, zodat je vanuit elke stand optimaal geniet van deze kristalheldere monitor." +
                                          " Een voordeel van deze monitor is dat hij over 4 USB 2.0-aansluitingen beschikt, zodat je gemakkelijk apparatuur" +
                                          " zoals een muis, toetsenbord of mp3speler direct op de Dell UltraSharp U2312HM aansluit.",
                    FiguurURL = "",
                    Prijs = 177.99M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Monitoren / Touchscreens")
                },
                new Product
                {
                    Artikelnummer = "RA-MO-0111",
                    Artikelnaam = "Dell UltraSharp U2412M " +
                                  "LED-monitor",
                    Artikelomschrijving = "24'' - 1920 x 1200 - IPS - 300 cd/m2 - 1000:1 - 8 ms - DVI, VGA - zwart" +
                                          " Geniet van breedbeeldprestaties, zoals u dat wilt.De U2412M heeft een 24” scherm met" +
                                          " een beeldverhouding van 16:10, IPS-technologie en LED achtergrondverlichting en biedt" +
                                          " een helder beeld en verbluffend veel aanpassingsmogelijkheden voor elke stijl." +
                                          " Ervaar IPS-technologie, met een brede kijkhoek en hoogwaardige kleurweergave voor een ongeëvenaarde" +
                                          " kijkervaring.Verander met een druk op de knop uw instellingen voor energieverbruik, helderheid van tekst en" +
                                          " kleurentemperatuur om energie te besparen met dit milieubewust ontworpen beeldscherm.",
                    FiguurURL = @"Content/images/RA-MO-0111.jpg",
                    Prijs = 242.9M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Monitoren / Touchscreens")
                },
                new Product
                {
                    Artikelnummer = "RA-AU-0120",
                    Artikelnaam = "Logitech LS21" +
                                  " Luidsprekersysteem",
                    Artikelomschrijving = "Voor PC - 2.1-kanaal - 7 Watt (Totaal)" +
                                          " 2 x satellietluidspreker - 1.5 Watt - 4 Ohm, 1 x subwoofer - 4 Watt - 4 Ohm" +
                                          " Satellietluidspreker : 8.5 cm x 8.2 cm x 14.6 cm, Subwoofer : 14 cm x 17.8 cm x 19 cm ",
                    FiguurURL = "",
                    Prijs = 25.41M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Speakers / hoofdtelefoons")
                },
                new Product
                {
                    Artikelnummer = "RA-AU-0121",
                    Artikelnaam = "Logitech Gaming" +
                                  " Headset G230 ",
                    Artikelomschrijving =
                        "G230 levert hoogwaardig stereogeluid zodat je van begin tot eind in de game kunt opgaan" +
                        " met oorstukjes die een dun en licht ontwerp hebben, zonder afbreuk te doen aan de" +
                        " audiokwaliteit.We hebben de oorstukjes van de G230 voorzien van een zorgvuldig" +
                        " geselecteerde stof voor sporters voor een comfortabele, zachte pasvorm, zelfs na" +
                        " urenlang gebruik.",
                    FiguurURL = @"Content/images/RA-AU-0121.jpg",
                    Prijs = 58.99M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Speakers / hoofdtelefoons")
                },
                new Product
                {
                    Artikelnummer = "RA-EX-0200",
                    Artikelnaam = "Transcend JetFlash 500",
                    Artikelomschrijving = "USB-Flashstation / 16 GB / Groen / software meegeleverd",
                    FiguurURL = @"Content/images/RA-EX-0200.jpg",
                    Prijs = 10.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Externe dataopslag")
                },
                new Product
                {
                    Artikelnummer = "RA-EX-0201",
                    Artikelnaam = "Transcend JetFlash 500 Mobile",
                    Artikelomschrijving =
                        "Houd je data volledig beschermd met de Transcend StoreJet 25M2 portable harde schijf. Door middel" +
                        " van een uit drie delen bestaande schok beschermings systeem, bestaande uit een vibratie absorberende" +
                        " siliconen omhulsel, versterkte behuizing en een verend opgestelde interne harde schijf als laatste" +
                        " verdedigingslinie, beschermt de StoreJet 25M2 uw data tegen de meeste extreme trillingen en schokken.",
                    FiguurURL = @"Content/images/RA-EX-0201.jpg",
                    Prijs = 57.14M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Externe dataopslag")
                },
                new Product
                {
                    Artikelnummer = "RA-MO-0202",
                    Artikelnaam = "Dell UltraSharp U2312HM",
                    Artikelomschrijving =
                        "De Dell UltraSharp U2312HM is een genot voor je ogen. Door de IPS-techniek geniet je van kristalheldere kleuren en dit is vanuit" +
                        " elke hoek te zien.Met een IPS-scherm blijft het beeld namelijk haarscherp vanuit elke kijkhoek.De Dell" +
                        " UltraSharp U2312HM beschikt over ruime mogelijkheden voor draaien, kantelen, roteren en is in de hoogte",
                    FiguurURL = @"Content/images/RA-MO-0202.jpg",
                    Prijs = 177.99M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Monitoren / Touchscreens")
                },
                new Product
                {
                    Artikelnummer = "RA-MO-0203",
                    Artikelnaam = "Dell UltraSharp U2713HM",
                    Artikelomschrijving =
                        "De 27” UltraSharp U2713HM monitor bidet helderheid van bioscoopniveau. Blijf productief dankzij de instellingen" +
                        " voor kijkcomfort en connectiviteit.WQHD-resolutie en nauwkeurige kleuren, rechtstreeks uit de verpakking:" +
                        " geweldige helderheid met een resolutie van 2.560 x 1.440 en meer dan 3,6 miljoen pixels. Biedt een kleurenbereik" +
                        " van meer dan 99% sRGB.",
                    FiguurURL = @"Content/images/RA-MO-0203.jpg",
                    Prijs = 474.9M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Monitoren / Touchscreens")
                },
                new Product
                {
                    Artikelnummer = "RA-AU-0204",
                    Artikelnaam = "Fantec SHS-221BT-RD Bluetooth Headphones",
                    Artikelomschrijving =
                        "De draadloze SHS-221BT stereo-headset van Fantec geeft u tot wel tien meter bewegingsvrijheid dankzij" +
                        " Bluetooth-technologie",
                    FiguurURL = @"Content/images/RA-AU-0204.jpg",
                    Prijs = 32.55M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Speakers / hoofdtelefoons")
                },
                new Product
                {
                    Artikelnummer = "RA-AU-0205",
                    Artikelnaam = "SteelSeries Siberia V2",
                    Artikelomschrijving =
                        "De SteelSeries Siberia v2 Full-size Headset, is een licht-gewicht gaming headset, met een intrekbare microfoon." +
                        " Door het gesloten ontwerp van deze headset, wordt je tijdens het gamen niet door de omgeving gestoord en" +
                        "  hoor je alles, wat er in het spel om je heen gebeurd.",
                    FiguurURL = @"Content/images/RA-AU-0205.jpg",
                    Prijs = 177.99M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Speakers / hoofdtelefoons")
                },
                new Product
                {
                    Artikelnummer = "RA-EX-300",
                    Artikelnaam = "Toshiba Stor E Basics 500 GB" +
                                  " USB(zwart )",
                    Artikelomschrijving = "Zet bestanden snel over met superspeed USB 3,0 en bewaar tot  1,5 GB aan" +
                                          " gegevens op Stor.E.Basics externe" +
                                          " Eenvoudig te gebruiken neerwaarts compatibel met USB 2,0 en gereed voor" +
                                          " gebruik  met Microsoft Windows zonder dat u Software moet installeren.",
                    FiguurURL = @"Content/images/RA-EX-300.jpg",
                    Prijs = 47.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Externe dataopslag")
                },
                new Product
                {
                    Artikelnummer = "RA-EX-301",
                    Artikelnaam = "LaCie d2 Quadra" +
                                  " V3 2 TB USB 2.0/800/ e SATA",
                    Artikelomschrijving =
                        "Met de USB 3,0- interface van 5GB/s is de LaCie d2 Quadra Hard Disk het ideale" +
                        " hulpmiddel voor de creatieve professionals die zowel hoge snelheden als een grote" +
                        " opslagcapaciteit nodig hebben.",
                    FiguurURL = @"Content/images/RA-EX-301.jpg",
                    Prijs = 173M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Externe dataopslag")
                },
                new Product
                {
                    Artikelnummer = "RA-MO-302",
                    Artikelnaam = "Philips V-line 193V5LSB2" +
                                  " Led-monitor-18.5''",
                    Artikelomschrijving = "Philips V-line 193V5LSB2 -Led monitor -18.5'' met achtergrondverlichting" +
                                          "43,7 cm x 17 cm x 33,8 cm met standaardt textuurzwart, zwart streepjespatroon",
                    FiguurURL = @"Content/images/RA-MO-302.jpg",
                    Prijs = 96.79M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Monitoren / Touchscreens")
                },
                new Product
                {
                    Artikelnummer = "RA-MO-303",
                    Artikelnaam = "HP Compac L5009tm-Led-monitor-15''",
                    Artikelomschrijving = "HP Compaq L5009tm,touchscreen. Beeldschermdiagonaal 381mm" +
                                          " responstijd 17ms, helderheid 225cd/m²,stroomverbruik30w,stroomverbruik in" +
                                          " standby 4w.Afmetingen 350x55x280mm, afmetingen met voet 350x175x310mm" +
                                          " kleur: zwart",
                    FiguurURL = @"Content/images/RA-MO-303.jpg",
                    Prijs = 514.96M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Monitoren / Touchscreens")
                },
                new Product
                {
                    Artikelnummer = "RA-AU-304",
                    Artikelnaam = "Stereo headset HS-2100" +
                                  " Trust",
                    Artikelomschrijving =
                        "Stereo headset met verstelbare microfoon,handsfree videoconferencing, chatten," +
                        " online gaming en telefonietoepassing." +
                        " Handvrije volumeregelingin kabel geintregeerd, uiterstgevoelige ommidirectionele" +
                        " microfoon, compatibel met MSN Messenger.",
                    FiguurURL = @"Content/images/RA-AU-304.jpg",
                    Prijs = 8M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Speakers / hoofdtelefoons")
                },
                new Product
                {
                    Artikelnummer = "RA-AU-305",
                    Artikelnaam = "SteelSeries 7H USB" +
                                  " Headset zwart",
                    Artikelomschrijving =
                        "De SteelSeries 7H USB versie biedt 7,1 Virtual surround en zorgt ervoor dat games" +
                        " overal hetzelfde geluid en instellingen overbrengt ongeacht waar men zich ter wereld" +
                        " bevindt of op welke computer men speelt" +
                        "  Zijn USB geluidskaart biedt vooraf ingestelde ,geoptimaliseerde profielen voor zowel" +
                        "  gaming als muziek." +
                        " De SteelSeries 7H USB kan ook worden gedemonteerd in 4 afzonderlijke stukken om" +
                        "  die het mogelijk maakt het makkelijk te vervoeren.",
                    FiguurURL = @"Content/images/RA-AU-305.jpg",
                    Prijs = 110M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Speakers / hoofdtelefoons")
                },
                new Product
                {
                    Artikelnummer = "RA-AU-306",
                    Artikelnaam = "Creative Speaker D80Bluetooth (zwart )",
                    Artikelomschrijving =
                        "Vervang u bedraade luidsprekers door de Creative D80 ,een compacte draadloze" +
                        " luidpreker, die u kan laten genieten van u favoriete muziek." +
                        " Met de bluetooth- technologie en de ingebouwde stroomadaptor hoeft u alleen de stekker" +
                        " in het stopcontact te steken" +
                        "  Dit artikel is verkrijgbaar in 4 kleuren.",
                    FiguurURL = @"Content/images/RA-AU-306.jpg",
                    Prijs = 33.5M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Speakers / hoofdtelefoons")
                },
                new Product
                {
                    Artikelnummer = "RA-AU-307",
                    Artikelnaam = "Sony Speaker NS410.LAN,WLAM" +
                                  " zwart",
                    Artikelomschrijving =
                        "2 weg WI-FI-luidsprekerssysteem met 5 luidsprekers,4x tweeteren 1x roofer van 110mm" +
                        "  AirPlay,volledig directioneel geluid(360°)",
                    FiguurURL = @"Content/images/RA-AU-307.jpg",
                    Prijs = 183M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Speakers / hoofdtelefoons")
                },
                new Product
                {
                    Artikelnummer = "RA-IN-0819",
                    Artikelnaam = "Logitech Wireless Combo MK270 AZERTY",
                    Artikelomschrijving =
                        "Met deze draadloze Logitech Wireless Combo heb je tot wel 10 meter bereik, " +
                        "  dankzij de usb nano ontvanger.Hierdoor heb je geen warboel van draden meer." +
                        "  De combo heeft een compact en vlak design en toetsen van normaal formaat." +
                        "  De MK270 is Plug & Play, dus zonder installatie te gebruiken op elke desktop en" +
                        "   laptop. De 8 sneltoetsen bieden je snelle en directe toegang tot muziek, e-mail" +
                        " en andere programma's waardoor je vlotter werkt. De combo is eveneens erg" +
                        "  zuinig en morsbestendig, dus maak je geen zorgen als je een drankje omstoot." +
                        "  De optische muis werkt zeer nauwkeurig en is prettig in gebruik.De batterijen" +
                        "  van het toetsenbord gaan tot 24 maanden mee en van de muis tot 12 maanden.",
                    FiguurURL = @"Content/images/RA-IN-0819.jpg",
                    Prijs = 39.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Bedieningsapparatuur")
                },
                new Product
                {
                    Artikelnummer = "RA-IN-0820",
                    Artikelnaam = "Logitech G19S Gaming Toetsenbord Azerty",
                    Artikelomschrijving =
                        "Dit toetsenbord zit boordevol extra's om tijdens het gamen boven je tegenstan-" +
                        " der te eindigen.Het bedrade toetsenbord beschikt over een kantelbaar kleuren" +
                        " lcd-scherm die niet alleen informatie over je game of computer weergeeft, maar" +
                        " ook diashows en video's kan afspelen. Opties heb je genoeg met de 12 program-" +
                        "  meerbare toetsen die je tot wel 36 verschillende functies kunt toewijzen.Daar-" +
                        " naast kun je zelf toetsencombinaties verzinnen en zelf toetsen uitschakelen. De" +
                        " toetsen zijn verlicht dus kan je moeiteloos gamen in het donker en de kleuren" +
                        " zijn zelfs aan te passen. Door 2 geïntegreerde USB-poorten heb je altijd extra" +
                        "  aansluitmogelijkheden bij de hand.",
                    FiguurURL = @"Content/images/RA-IN-0820.jpg",
                    Prijs = 179.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Bedieningsapparatuur")
                }
            );

            //Laptop & PC

            context.Producten.AddOrUpdate(p => p.Artikelnummer,


                new Product
                {
                    Artikelnummer = "PC-TB-0130",
                    Artikelnaam = "Sony Xperia Tablet " +
                                  "Z SGP312E4",
                    Artikelomschrijving = "32 GB - 10.1'' TFT ( 1920 x 1200 ) - rear camera + front camera - Wi-Fi" +
                                          " De Xperia Tablet Z is ontworpen met de beeldtechniek van Sony, voor de levendigste" +
                                          " kijkervaring die u zich maar kunt voorstellen.De 25,6cm(10.1'') HD Reality-display bevat" +
                                          " de Mobile BRAVIA Engine 2, die automatisch ieder beeld optimaliseert.En met de volledige" +
                                          " kleurendisplay wordt elke scène voller, helderder en adembenemend levendig.",
                    FiguurURL = @"Content/images/PC-TB-0130.jpg",
                    Prijs = 583.16M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Tablets")
                },
                new Product
                {
                    Artikelnummer = "PC-TB-0131",
                    Artikelnaam = "Samsung Galaxy Tab 2 (10.1) " +
                                  " WiFi - Tablet",
                    Artikelomschrijving = "Android 4.0 - 16 GB - 10.1" +
                                          " Met de Samsung Galaxy Tab 2 (10.1) op zak ben je altijd mobiel met een mini-laptop." +
                                          " Het grote display van 10.1 inch zorgt ervoor dat je comfortabel gebruik kunt maken en" +
                                          " genieten van alle multimedia activiteiten.De Samsung Galaxy Tab 2 (10.1) draait op het" +
                                          " Android platform 4.0 Ice Cream Sandwich.Ontdek de vele voordelen die dit platform" +
                                          "  met zich meebrengt.De 1 GHz dual core processor op de Samsung Galaxy Tab 2 (10.1)" +
                                          " zorgt voor snelle en sterke prestaties.",
                    FiguurURL = @"Content/images/PC-TB-0131.jpg",
                    Prijs = 254M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Tablets")
                },
                new Product
                {
                    Artikelnummer = "PC-AP-0140",
                    Artikelnaam = "Apple iPad 2 Wi-Fi " +
                                  "Tablet",
                    Artikelomschrijving = "6 GB - 9.7'' IPS ( 1024 x 768 ) - rear camera + front camera - wit" +
                                          " Apple iPad 2, Wi-Fi - tablet - iOS 5 - 16 GB - 9.7" +
                                          " afmetingen: 18.6 cm x 0.9 cm x 24.1 cm",
                    FiguurURL = @"Content/images/PC-AP-0140.jpg",
                    Prijs = 378M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Apple")
                },
                new Product
                {
                    Artikelnummer = "PC-AP-0141",
                    Artikelnaam = "Apple Smart Cover",
                    Artikelomschrijving = "Beschermende bedekking voor web tablet - leer - zwart" +
                                          " Smart Cover is niet zomaar een hoes.Smart Cover is namelijk tegelijk met iPad 2 ontworpen" +
                                          " en past daar dan ook perfect bij. Het is een dunne, duurzame hoes die met magneten op zijn" +
                                          " plaats wordt gehouden, zodat hij perfect past. De sluimerstand van je iPad wordt automatisch" +
                                          " in- en uitgeschakeld. Het is een handige standaard voor als je wilt lezen, film kijken of typen." +
                                          " De voering van microvezel zorgt ervoor dat het scherm van iPad schoon blijft. ",
                    FiguurURL = @"Content/images/PC-AP-0141.jpg",
                    Prijs = 63.72M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Apple")
                },
                new Product
                {
                    Artikelnummer = "PC-LT-0150",
                    Artikelnaam = "Acer Aspire " +
                                  " V5-572P-33214G50AII",
                    Artikelomschrijving = "Core i3 3217U / 1.8 GHz - RAM 4 GB - vaste schijf 500 GB" +
                                          " Met de V5-serie loopt u voorop als het gaat om de nieuwste digitale trends.Deze tijdloze" +
                                          " computer beschikt over een 15,6'' Touch LED scherm en dankzij de krachtige processors en" +
                                          " grafische voorzieningen kunt u eenvoudig multitasken met de nieuwste creatieve applicaties," +
                                          "  internetten, gamen en nog veel meer.De Aspire V5-572P is uitgerust met een" +
                                          "  Intel® Core i3 3217U processor, een 500GB harde schijf, WLAN b/g/n, 4GB geheugen en een" +
                                          "  Intel® HD Graphics 4000 grafische chipset. De notebook wordt geleverd met" +
                                          "  Windows® 8 (64-bit).",
                    FiguurURL = @"Content/images/PC-LT-0150.jpg",
                    Prijs = 578M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Laptops")
                },
                new Product
                {
                    Artikelnummer = "PC-LT-0151",
                    Artikelnaam = "HP ProBook 450 G0" +
                                  " Core i5 3230M / 2.6 GHz",
                    Artikelomschrijving =
                        "HP ProBook 450 G0 - 15.6'' - Core i5 3230M - downgrade van Windows 7 Pro 64-bit naar" +
                        " 8 Pro - 4 GB RAM - 500 GB HDD" +
                        " Downgrade van Windows 7 Pro 64-bit naar 8 Pro -reeds geinstalleerd: Windows 7" +
                        " Processor: Intel Core i5(3e Gen) 3230M / 2.6 GHz( 3.2 GHz ) / 3 MB Cache" +
                        "  Display: 15.6'' LED-achtergrondlicht HD antiglans 1366 x 768 / HD" +
                        " Afmetingen: 37.5 cm x 25.6 cm x 2.28 cm",
                    FiguurURL = @"Content/images/PC-LT-0151.jpg",
                    Prijs = 689.91M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Laptops")
                },
                new Product
                {
                    Artikelnummer = "PC-PC-0160",
                    Artikelnaam = "HP 600B " +
                                  "  Microtowermodel",
                    Artikelomschrijving = "1 x P G2020T / 2.5 GHz - RAM 2 GB - HDD 1 x 500 GB - DVD SuperMulti" +
                                          "  De computerbehoeften van uw bedrijf kunnen met een muisklik veranderen.U zoekt een pc" +
                                          "   die u bijhoudt. De HP 600B MT biedt u de hoge prestaties die nodig zijn voor processor- en" +
                                          "  grafisch-intensieve applicaties en een fraai nieuw design dat in elk thuiskantoor en iedere" +
                                          "   onderneming past. De HP 600B MT Microtower PC (H4M63EA) bevat een" +
                                          "  Intel® Pentium® G2020T en is tevens uitgerust met het Windows 8 Professional" +
                                          "   besturingssysteem, een Intel® H61 chipset en een Intel® HD Graphics grafische chipset. ",
                    FiguurURL = @"Content/images/PC-PC-0160.jpg",
                    Prijs = 392.25M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Desktop PC’s")
                },
                new Product
                {
                    Artikelnummer = "PC-PC-0161",
                    Artikelnaam = "AzGameSystem Maximianus" +
                                  " Towermodel",
                    Artikelomschrijving = "1 x Intel Core i7 3820 / 3.6 GHz - RAM 16 GB - vaste schijf 1 x 2000 GB" +
                                          " Voeding: CoolerMaster Silent Pro M2 620W - voeding - 620 Watt" +
                                          " Moederbord: ASUS P9X79 - moederbord - ATX - LGA2011 Socket - X79" +
                                          "  Processor: Intel Core i7 3820 / 3.6 GHz processor + Cooler Master Hyper 412S" +
                                          " Videokaart: Sapphire RADEON HD 7850 - grafische adapter - Radeon HD 7850 - 2 GB" +
                                          "  Geheugen: Valuegeheugen - 16 GB : 2 x 8 GB - DIMM 240-pins - DDR3" +
                                          "  Besturingssysteem: Microsoft Windows 7 Home Premium 64Bit ",
                    FiguurURL = @"Content/images/PC-PC-0161.jpg",
                    Prijs = 1215M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Desktop PC’s")
                },
                new Product
                {
                    Artikelnummer = "PC-TB-0206",
                    Artikelnaam = "Samsung Galaxy Tab 2  (7.0) WIFI",
                    Artikelomschrijving =
                        "Met de krachtige 1 GHz dual core processor van de Samsung Galaxy Tab 7.0 is multitasken geen probleem. " +
                        " Ook sta je altijd en overal in contact met je vrienden, dankzij onder andere chatten via ChatON." +
                        " Bovendien connect je via Allshare je Tab gemakkelijk aan andere Samsung apparaten.",
                    FiguurURL = @"Content/images/PC-TB-0206.jpg",
                    Prijs = 179.5M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Tablets")
                },
                new Product
                {
                    Artikelnummer = "PC-AP-0208",
                    Artikelnaam = "Apple MacBook Air",
                    Artikelomschrijving =
                        "Met de superefficiënte processors in MacBook Air heb je meer tijd om nog meer voor elkaar te krijgen." +
                        "  Combineer dat met een veelzijdige reeks slimme en efficiënte voorzieningen en je hebt een ongekend krachtige notebook." +
                        "  Een notebook die bijna niets weegt.",
                    FiguurURL = @"Content/images/PC-AP-0208.jpg",
                    Prijs = 1028M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Apple")
                },
                new Product
                {
                    Artikelnummer = "PC-AP-0209",
                    Artikelnaam = "Apple Mac mini",
                    Artikelomschrijving = "DTS/ 1x Core i5/ 2.5GHz/ RAM 4 GB ",
                    FiguurURL = @"Content/images/PC-AP-0209.jpg",
                    Prijs = 639M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Apple")
                },
                new Product
                {
                    Artikelnummer = "PC-LT-0211",
                    Artikelnaam = "Acer TrafelMate P273" +
                                  "  M20204G32Mnks",
                    Artikelomschrijving = "Pentium 2020M/ 2.4 GHz/ Windows 8/ 64-bit/  4GB RAM ",
                    FiguurURL = @"Content/images/PC-LT-0211.jpg",
                    Prijs = 432.07M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Laptops")
                },
                new Product
                {
                    Artikelnummer = "PC-PC-0212",
                    Artikelnaam = "Hp 600B",
                    Artikelomschrijving =
                        "De HP 600B MT biedt u de hoge prestaties die nodig zijn voor processor- en grafisch-intensieve applicaties en" +
                        " een fraai nieuw design dat in elk thuiskantoor en iedere onderneming past." +
                        " De HP 600B MT Microtower PC (H4M63EA) bevat een Intel® Pentium® G2020T en is tevens uitgerust" +
                        "  met het Windows 8 Professional besturingssysteem," +
                        "  een Intel® H61 chipset en een Intel® HD Graphics grafische chipset.",
                    FiguurURL = @"Content/images/PC-PC-0212.jpg",
                    Prijs = 392.25M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Desktop PC’s")
                },
                new Product
                {
                    Artikelnummer = "PC-PC-0213",
                    Artikelnaam = "Azerty Aeolus Starter" +
                                  " I2012W8",
                    Artikelomschrijving =
                        "De AZERTY Aeolus I2012W8 Starter is een eenvoudige PC voor het uitvoeren van de dagelijkse computertaken." +
                        " Deze PC beschikt over een Intel® Pentium® G860 processor, biedt 500 GB opslagcapaciteit," +
                        " heeft 8 GB DDR3 geheugen, waarmee u snel en gemakkelijk kunt werken." +
                        " Deze PC wordt geleverd met Windows 8, exclusief monitor, toetsenbord en muis",
                    FiguurURL = @"Content/images/PC-PC-0213.jpg",
                    Prijs = 509M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Desktop PC’s")
                },
                new Product
                {
                    Artikelnummer = "PC-TB-308",
                    Artikelnaam = "Samsung Galaxy Tab 27.0P3110.7.o\"" +
                                  " zilver",
                    Artikelomschrijving =
                        "Deze tablet is ideaal voor onderweg. Dankzij het verassend lichte gewicht van de " +
                        " Samsung Galaxy Tab draag je deze gemakkelijk mee.Een ultra licht gewicht van 345" +
                        "  gram en slechts 10,5mm dun.Dankzij het slanke design is deze tablet prettig vast te" +
                        "  houden. Op deze tablet kun je optimaal Multitasken dankzij de krachtige 1GHz dual core" +
                        "  processor.",
                    FiguurURL = @"Content/images/PC-TB-308.jpg",
                    Prijs = 149.99M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Tablets")
                },
                new Product
                {
                    Artikelnummer = "PC-TB-309",
                    Artikelnaam = "HP Elitepad 900 D4T1544",
                    Artikelomschrijving =
                        "De zakelijke HP ElitePad 900 D4T15AA is een tablet met een 10,1 inch touchscreen." +
                        " Dankzij de superstevige aluminium behuizing kan de ElitePad 900 tegen een stootje." +
                        "  Het Gorilla Glass 2 voor het scherm zorgt ervoor dat de ElitePad goed beschermd" +
                        " is tegen krassen en vetafrukken." +
                        " Windows 8 Pro is geoptimaliseerd voor touchgebruik, dus je navigeert razendsnel door al jouw bedrijfsbestanden heen." +
                        " De HP ElitePad 900 D4T15AA beschikt over een Full HD-webcam aan de voorkant," +
                        " zodat je gemakkelijk deel neemt aan een online meeting." +
                        " Met de 8 megapixel camera aan de achterkant van de ElitePad maak je de mooiste foto's en video's." +
                        " De HP ElitePad 900 D4T15AA is voorzien van een 32 GB SSD-schijf." +
                        "  Wil je deze uitbreiden?" +
                        "   Dan kan je maximaal 64 GB extra toevoegen door middel van een microSDHC-kaartje.",
                    FiguurURL = @"Content/images/PC-TB-309.jpg",
                    Prijs = 544M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Tablets")
                }
            );

            //Servers

            context.Producten.AddOrUpdate(p => p.Artikelnummer,


                new Product
                {
                    Artikelnummer = "PC-TB-309",
                    Artikelnaam = "HP ProLiant MicroServer " +
                                  " Server",
                    Artikelomschrijving = "ultra microtowermodel - 1-wegs - 1 x Turion II Neo N54L / 2.2 GHz" +
                                          " Processor: 1 x AMD Turion II Neo N54L / 2.2 GHz(Dual-Core )" +
                                          " Cachegeheugen: 2 MB L2 Cache, 2 MB( 2 x 1 MB ) per processor" +
                                          "  RAM: 2 GB(geïnstalleerd) / 8 GB(max.) - DDR3 SDRAM - ECC - 800 MHz - PC3-10600" +
                                          " Harde schijf: 1 x 250 GB - SATA-300" +
                                          "  Afmetingen: 21 cm x 26 cm x 26.7 cm",
                    FiguurURL = @"Content/images/PC-TB-309.jpg",
                    Prijs = 224.9M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Hewlet Packard")
                },
                new Product
                {
                    Artikelnummer = "SV-HP-0171",
                    Artikelnaam = "HP ProLiant DL360e " +
                                  "Gen8 Entry - Server",
                    Artikelomschrijving =
                        "rack-uitvoering - 1U - 2-weg - 1 x Xeon E5-2403 / 1.8 GHz - RAM 4 GB - SATA" +
                        "  Processor: 1 x Intel Xeon E5-2403 / 1.8 GHz(Quad-Core ) - Intel QuickPath Interconnect" +
                        "  Cachegeheugen: 10 MB L3 Cache, 10 MB per processor" +
                        "  RAM: 4 GB(geïnstalleerd) / 192 GB(max.) - DDR3 SDRAM - ECC - 1066 MHz - PC3-10600" +
                        "  Harde schijf: geen HDD" +
                        "  Afmetingen: 43.46 cm x 75 cm x 4.32 cm",
                    FiguurURL = @"Content/images/SV-HP-0171.jpg",
                    Prijs = 1294.62M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Hewlet Packard")
                },
                new Product
                {
                    Artikelnummer = "SV-SM-0180",
                    Artikelnaam = "Supermicro MBD-X7DBR-8-B " +
                                  " moederbord",
                    Artikelomschrijving = "uitgebreide ATX - LGA771 Socket - 2 Ondersteund CPU's - i5000P" +
                                          " Compatibele processoren: Dual-Core Xeon 5100 serie, Quad-Core Xeon 5300 serie," +
                                          " Dual-Core Xeon 5200-serie, Quad-Core Xeon 5400-serie" +
                                          " Maximaal ondersteunend geheugen: 32 GB" +
                                          " Ondersteund RAM: 8 DIMM-sleuven - DDR2 SDRAM, ECC, volledig gebufferd" +
                                          " Opslagpoorten: 6 x SATA," +
                                          " USB-poortconfiguratie: 6 x USB",
                    FiguurURL = @"Content/images/SV-SM-0180.jpg",
                    Prijs = 415.96M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Supermicro")
                },
                new Product
                {
                    Artikelnummer = "SV-SM-0181",
                    Artikelnaam = "Supermicro - Voeding" +
                                  "  ( insteekmodule )",
                    Artikelomschrijving = "100/240 Volt wisselstroom V - 400 Watt" +
                                          " Sku's: PWS-0037" +
                                          "  Input Voltage: 100/240 Volt wisselstroom V" +
                                          "  Output Voltage: +3.3, +5, +12 V" +
                                          "   Stroomcapaciteit: 400 Watt",
                    FiguurURL = @"Content/images/SV-SM-0181.jpg",
                    Prijs = 59M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Supermicro")
                },
                new Product
                {
                    Artikelnummer = "SV-NS-0190",
                    Artikelnaam = "NETGEAR ReadyNAS " +
                                  " 316 RN31600 - NAS",
                    Artikelomschrijving = "0 GB - Serial ATA-300 - RAID 0, 1, 5, 6, 10 - Gigabit Ethernet - iSCSI" +
                                          " Met ReadyNAS kun je op een eenvoudige manier je digitale wereld centraliseren, toegankelijk" +
                                          " maken en delen.De ReadyNAS biedt opslag en ongekende bescherming van jouw bestanden," +
                                          "  toegang tot de opgeslagen gegevens vanaf elk webenabled apparaat en een bibliotheek van" +
                                          "  add-ons.De ReadyNas is ontworpen met gebruiksgemak in het achterhoofd.Zo worden" +
                                          "  apparaten automatisch ontdekt in de could en ze hebben een strakke, moderne interface. " +
                                          " De opgeslagen gegevens zijn beschermd met automatische RAID-configuratie.Ook biedt de" +
                                          " ReadyNAS thuisgebruikers de continue gegevensbescherming van onbeperkte snapshots," +
                                          "  samen met real-time anti-virus en native encryptie.Verder biedt de ReadyNAS remote toegang," +
                                          "  naadloze cloud-based file synchronisatie (ReadyDROP) en de mogelijkheid om gegevens te" +
                                          "  back-uppen van uw Mac overal ter wereld met het gebruik van Apple Time Machine.",
                    FiguurURL = @"Content/images/SV-NS-0190.jpg",
                    Prijs = 648.9M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Netwerk opslag (NAS)")
                },
                new Product
                {
                    Artikelnummer = "SV-NS-0191",
                    Artikelnaam = " Thecus Technology N16000 " +
                                  " NAS server",
                    Artikelomschrijving = "rack-uitvoering - SATA 6Gb/s / SAS 6Gb/s - Gigabit E" +
                                          " Max.ondersteunde capaciteit: 48 TB" +
                                          " Aantal geïnstalleerde apparaten/modules: 16 (max.)" +
                                          " Processor: 1 x Intel Xeon X3480" +
                                          "  Controller voor opslag: RAID - SATA 6Gb/s / SAS 6Gb/s - RAID 0, 1, 5, 6, 10, 50, JBOD, 60" +
                                          "  Netwerk: Netwerkadapter - insteekkaart - Ethernet, Fast Ethernet, Gigabit Ethernet" +
                                          "  Systeemvereisten: UNIX, Linux, Apple MacOS 9, Apple MacOS X, " +
                                          "  Microsoft Windows 2000/XP/Vista/7, Microsoft Windows 2003",
                    FiguurURL = @"Content/images/SV-NS-0191.jpg",
                    Prijs = 4823.52M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Netwerk opslag (NAS)")
                },
                new Product
                {
                    Artikelnummer = "SV-HP-0214",
                    Artikelnaam = "HP Proliant DL 120 G7",
                    Artikelomschrijving = "Server/ Rack uitvoering/ 1U",
                    FiguurURL = @"Content/images/SV-HP-0214.jpg",
                    Prijs = 601.81M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Hewlet Packard")
                },
                new Product
                {
                    Artikelnummer = "SV-HP-0215",
                    Artikelnaam = "HP Proliant DL 160 " +
                                  " Gen 8 Base",
                    Artikelomschrijving = "Server/ Rack uitvoering/ 1U",
                    FiguurURL = @"Content/images/SV-HP-0215.jpg",
                    Prijs = 1644.26M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Hewlet Packard")
                },
                new Product
                {
                    Artikelnummer = "SV-SM-0216",
                    Artikelnaam = "Supermicro SuperServer  6017B-MTLF",
                    Artikelomschrijving = "Server/ Rack uitvoering/ 1U/ 2-weg/ RAM 0 MB/ SATA",
                    FiguurURL = @"Content/images/SV-SM-0216.jpg",
                    Prijs = 765.01M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Supermicro")
                },
                new Product
                {
                    Artikelnummer = "SV-SM-0217",
                    Artikelnaam = "Supermicro SuperServer  1027R-WRF",
                    Artikelomschrijving = "Server/ Rack uitvoering/ 1U/ 2-weg/ RAM 0 MB/ SATA",
                    FiguurURL = @"Content/images/SV-SM-0217.jpg",
                    Prijs = 1179.94M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Supermicro")
                },
                new Product
                {
                    Artikelnummer = "SV-NS-0218",
                    Artikelnaam = "LaCie 2big",
                    Artikelomschrijving = "NAS Server/ 8TB/ HD 4TBx2/ RAID 0.1/ USB 2.0/ " +
                                          " Gigabit Ethernet",
                    FiguurURL = @"Content/images/SV-NS-0218.jpg",
                    Prijs = 568.88M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Netwerk opslag (NAS)")
                },
                new Product
                {
                    Artikelnummer = "SV-NS-0219",
                    Artikelnaam = "Synologie Disk Station " +
                                  " DS413j",
                    Artikelomschrijving = "NAS/ 0 GB/ serial ATA-300",
                    FiguurURL = @"Content/images/SV-NS-0219.jpg",
                    Prijs = 293.9M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Netwerk opslag (NAS)")
                }

            );

            //Netwerk
            context.Producten.AddOrUpdate(p => p.Artikelnummer,

                new Product
                {
                    Artikelnummer = "NW-RT-0401",
                    Artikelnaam = "LINKSYS EA6700 SMART WIFI ROUTER",
                    Artikelomschrijving = "LINKSYS EA6700 SMART WIFI ROUTER" +
                                          " Betrouwbare brede draadloze dekking." +
                                          " Draadloze snelheid tot 300Mbps" +
                                          "4 Gigabit-Ethernetpoorten" +
                                          " Snel te installeren",
                    FiguurURL = @"Content/images/NW-RT-0401.jpg",
                    Prijs = 179.99M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Routers")
                },
                new Product
                {
                    Artikelnummer = "NW-RT-0402",
                    Artikelnaam = "TP-LINK TL-WDR3600 ROUTER",
                    Artikelomschrijving = "TP-LINK TL-WDR3600 ROUTER" +
                                          " N600 draadloze dubbelband gigabit router" +
                                          " 2 USB-aansluitingen voor het delen van printers, bestanden of media met" +
                                          "  vrienden of familie lokaal of via het internet." +
                                          "  Beveiliging instellen met 1 toets.",
                    FiguurURL = @"Content/images/NW-RT-0402.jpg",
                    Prijs = 69.99M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Routers")
                },
                new Product
                {
                    Artikelnummer = "NW-SW-0403",
                    Artikelnaam = "TP-LINK 16 PORT SWITCH 10/100/1000",
                    Artikelomschrijving = "Datatransport full-duplexccapaciteit, automatische detectie per apparaat," +
                                          " automatische onderhandeling, auto-uplink(auto DMI/MDI-X), pakket filteren," +
                                          "  opslaan en verder, aan de muur bevestigbaar Qualiti of Service(QoS)" +
                                          "  MA C-adrestabelgrootte 5K invoergegevens" +
                                          " Afmetingen(BxDxH) 19,3 cm x 11,9 cm x 3,2 cm",
                    FiguurURL = @"Content/images/NW-SW-0403.jpg",
                    Prijs = 74.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Switchen")
                },
                new Product
                {
                    Artikelnummer = "NW-SW-0404",
                    Artikelnaam = "NETGEAR PROSAFE GS100E",
                    Artikelomschrijving = "Semi-managed (alleen via Windows applicatie), Datatransport, Layer " +
                                          " 2-omschakeling, automatische onderhandeling, VLAN-ondersteuning, IGMP-" +
                                          " spionage, DoS bescherming tegen aanval, gespiegelde poorten, Broadcast" +
                                          "  Storm Control, Quality of Service(QoS)" +
                                          "  5x Ethernet 1Gbps",
                    FiguurURL = @"Content/images/NW-SW-0404.jpg",
                    Prijs = 21.93M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Switchen")
                },
                new Product
                {
                    Artikelnummer = "NW-NC-0405",
                    Artikelnaam = "LINKSYS WIRELESS MINI USB",
                    Artikelomschrijving = "LINKSYS WIRELESS MINI USB ADAPTER AC 580 DUAL BAND" +
                                          " USB 2.0" +
                                          " Verbinding(wlan) 802.11a, 802.11ac, 802.11b, 802.11g, 802.11n" +
                                          " Wifi snelheid 430Mbps" +
                                          "  Vaste antenne",
                    FiguurURL = @"Content/images/NW-NC-0405.jpg",
                    Prijs = 29.89M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Netwerkkaarten")
                },
                new Product
                {
                    Artikelnummer = "NW-NC-0406",
                    Artikelnaam = "TP-LINK TL-WN822N",
                    Artikelomschrijving = "TP-LINK TL-WN822N" +
                                          " USB 2.0" +
                                          " Verbinding(wlan) 802.11b, 802.11g, 802.11n" +
                                          "   Wifi snelsheid 300Mbps" +
                                          "  Vaste antenne",
                    FiguurURL = @"Content/images/NW-NC-0406.jpg",
                    Prijs = 10.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Netwerkkaarten")
                }
            );


            //Software
            context.Producten.AddOrUpdate(p => p.Artikelnummer,

                new Product
                {
                    Artikelnummer = "SW-AD-0407",
                    Artikelnaam = "ADOBE ACROBAT XI PRO",
                    Artikelomschrijving = "Nieuwe Adobe Forms Central-desktopapparatuur, om snel PDF- of web-" +
                                          " formulieren te maken",
                    FiguurURL = @"Content/images/SW-AD-0407.jpg",
                    Prijs = 207.01M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Adobe")
                },
                new Product
                {
                    Artikelnummer = "SW-AD-0408",
                    Artikelnaam = "ADOBE PHOTOSHOP LIGHTROOM 5",
                    Artikelomschrijving = "Breng eenvoudig krachtige aanpassingen aan en gebruik geavanceerde" +
                                          " besturingselementen om je afbeeldingen te ordenen, te perfectioneren" +
                                          " en te delen.",
                    FiguurURL = @"Content/images/SW-AD-0408.jpg",
                    Prijs = 129.15M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Adobe")
                },
                new Product
                {
                    Artikelnummer = "SW-MS-0409",
                    Artikelnaam = "OFFICE 2013 VOOR THUISGEBRUIK EN STUDENTEN",
                    Artikelomschrijving = "Met deze softwaretools die speciaal zijn ontwikkeld om je te helpen de" +
                                          " dingen die je het vaakst doet, uit te voeren, bereik je meer. ",
                    FiguurURL = @"Content/images/SW-MS-0409.jpg",
                    Prijs = 139M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Microsoft")
                },
                new Product
                {
                    Artikelnummer = "SW-AV-0411",
                    Artikelnaam = "NORTON ANTIVIRUS 2014",
                    Artikelomschrijving = "Beschermt je terwijl je online surft, winkelt en bankiert." +
                                          " Beschermt je tegen sociale media-scams" +
                                          " Stopt de online gevaren van nu en de toekomst." +
                                          "  Blokkeert geïnfecteerde en gevaarlijke downloads. ",
                    FiguurURL = @"Content/images/SW-MS-0411.jpg",
                    Prijs = 49.99M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Antivirus")
                },
                new Product
                {
                    Artikelnummer = "SW-MS-0410",
                    Artikelnaam = "AUTOROUTE 2013",
                    Artikelomschrijving = "Bijgewerkte kaarten van Europa met meer dan 3 miljoen interessante" +
                                          " locaties en meer dan 9 miljoen kilometer navigeerbare wegen. ",
                    FiguurURL = @"Content/images/SW-AV-0410.jpg",
                    Prijs = 38M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Microsoft")
                },
                new Product
                {
                    Artikelnummer = "SW-AV-0412",
                    Artikelnaam = "KASPERSKY INTERNET SECURITY 2014",
                    Artikelomschrijving = "Internetbeveiligingssoftware voor de bescherming van je pc, gegevens en" +
                                          " identiteit." +
                                          "  Bescherming tegen malware" +
                                          " Internetbeveiliging" +
                                          "  Identiteitsbescherming" +
                                          "  Anti-phishingbescherming" +
                                          "  Geavanceerd ouderlijk toezicht ",
                    FiguurURL = @"Content/images/SW-AV-041.jpg",
                    Prijs = 69.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Antivirus")
                }
            );

            //Printen / Scannen
            context.Producten.AddOrUpdate(p => p.Artikelnummer,

                new Product
                {
                    Artikelnummer = "PR-IJ-0413",
                    Artikelnaam = "CANON PIXMA MG7150",
                    Artikelomschrijving = "Printsnelheid zwart/wit 15 p/m" +
                                          " Printsnelheid kleur 10 p/m" +
                                          " Resolutie kleur 4800 x 1200 dpi" +
                                          "  Afmetingen(H x B x D) 14,8 x 46,6 x 36,9 cm," +
                                          " Kleur zilver",
                    FiguurURL = @"Content/images/PR-IJ-0413.jpg",
                    Prijs = 159M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Inkjet printers")
                },
                new Product
                {
                    Artikelnummer = "PR-IJ-0414",
                    Artikelnaam = "HP DESKJET 1010",
                    Artikelomschrijving = "Printsnelheid zwart/wit 7p/m" +
                                          "  Printsnelheid kleur 4 p/m" +
                                          "  Afdrukresolutie 1200 x 4800 dpi",
                    FiguurURL = @"Content/images/PR-IJ-0414.jpg",
                    Prijs = 49M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Inkjet printers")
                },
                new Product
                {
                    Artikelnummer = "PR-LP-0415",
                    Artikelnaam = "HP P1102W",
                    Artikelomschrijving = "Laser monochroom" +
                                          " Afdrukresolutie 600 x 600 dpi" +
                                          " Afdruksnelheid zwart/wit 18 p/m",
                    FiguurURL = @"Content/images/PR-LP-0415.jpg",
                    Prijs = 99M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Laserprinters")
                },
                new Product
                {
                    Artikelnummer = "PR-LP-0416",
                    Artikelnaam = "HP LASERJET PRO COLOR M251N",
                    Artikelomschrijving = "Laser kleur" +
                                          " Afdrukresolutie 600 x 600 dpi" +
                                          " Afdruksnelheid zwart/wit en kleur 14np/m",
                    FiguurURL = @"Content/images/PR-LP-0416.jpg",
                    Prijs = 199M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Laserprinters")
                },
                new Product
                {
                    Artikelnummer = "PR-SC-0417",
                    Artikelnaam = "CANON LIDE 110",
                    Artikelomschrijving = "Optische resolutie 2400 x 4800 dpi" +
                                          " Scansnelheid in previewmodus 18 sec" +
                                          " Kleurdiepte 48 bits",
                    FiguurURL = @"Content/images/PR-SC-0417.jpg",
                    Prijs = 60M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Scanners")
                },
                new Product
                {
                    Artikelnummer = "PR-SC-0418",
                    Artikelnaam = "BROTHER ADS-2600W",
                    Artikelomschrijving = "Maximale resolutie 600 x 600 dpi" +
                                          " Kleurendiepte 24 bit" +
                                          " Scansnelheid 24 pagina's per minuut",
                    FiguurURL = @"Content/images/PR-SC-0418.jpg",
                    Prijs = 499.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Scanners")
                }
            );


            //Componenten
            /*context.Set<Product>().AddOrUpdate(p => p.Artikelnummer);*/ // kan ook
            context.Producten.AddOrUpdate(p => p.Artikelnummer,

                new Product
                {
                    Artikelnummer = "CM-BE-0801",
                    Artikelnaam = "Cooler Master K-280",
                    Artikelomschrijving =
                        "De Cooler Master K-280 computerbehuizing beschikt over 1 vooraf geïnstalleerde" +
                        " casefan, maar heeft er plek voor 3 met een maximale grootte van 120 mm." +
                        "  De Midi Tower behuizing heeft aardig wat ruimte en is geschikt voor Micro-ATX" +
                        "  en ATX moederborden en videokaarten met een maximale lengte van 315 mm." +
                        "  Tevens is er ruimte voor 7 harde schijven en 3 optische drives." +
                        "  Ben jij op zoek naar een Midi behuizing voor een basis-pc? Kies dan voor de" +
                        "  Cooler Master K-280.",
                    FiguurURL = @"Content/images/CM-BE-0801.jpg",
                    Prijs = 44.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Behuizingen")
                },
                new Product
                {
                    Artikelnummer = "CM-BE-0802",
                    Artikelnaam = "Fractal Design Node 304",
                    Artikelomschrijving = "De Fractal Design Node 304 behuizing is geschikt voor het bouwen van een " +
                                          " compact systeem.Ondanks het compacte formaat is er voldoende ruimte voor" +
                                          " alle componenten. Zo is er plaats voor zes harde schijven als je een server" +
                                          " bouwt, of je plaatst een videokaart als je een gamer bent. Met de airflow zit het" +
                                          "  ook goed, hier zorgen drie grote fans voor, met verwijderbare filters.Wil je een" +
                                          "  kleine server bouwen, een gamerskast of juist een media PC, dan zit je met deze" +
                                          " computerbehuizing zeker goed.",
                    FiguurURL = @"Content/images/CM-BE-0802.jpg",
                    Prijs = 84.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Behuizingen")
                },
                new Product
                {
                    Artikelnummer = "CM-DV-0803",
                    Artikelnaam = "Asus Blu-ray Brander SBW-06D2X-U",
                    Artikelomschrijving =
                        "De Asus Blu-ray Brander is in staat om blu-ray schijven te branden tot een grote" +
                        " van 128 GB.Zo kan je nog meer informatie kwijt op een schijfje.Met deze kan" +
                        " je natuurlijk ook cd's en dvd's branden. Naast het branden van schijven is het" +
                        " ook mogelijk om blu-ray schijven te lezen, ook wanneer het een 3D blu-ray schijf" +
                        " betreft.Deze brander sluit je aan via een usb-poort op je laptop of PC, een" +
                        " aparte voeding is niet nodig. Met de meegeleverde standaard kan je kiezen of je" +
                        " de brander in liggende of staande positie gebruikt.Let op: Dit product wordt ge-" +
                        " leverd met software die alleen op windows of Mac OS x 10.6 of hoger draait.",
                    FiguurURL = @"Content/images/CM-DV-0803.jpg",
                    Prijs = 119.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "DVD/Blu Ray")
                },
                new Product
                {
                    Artikelnummer = "CM-DV-0804",
                    Artikelnaam = "Samsung DVD-RW external slim black SE-208DB",
                    Artikelomschrijving = "De Samsung DVD-RW External Slim Black DVD en CD-ROM brander is lekker" +
                                          " compact van formaat.Neem deze brander makkelijk mee in je laptoptas.Steek" +
                                          " de USB kabel in je laptop en je kan direct aan de slag met het branden van CD's " +
                                          " en DVD's.",
                    FiguurURL = @"Content/images/CM-DV-0804.jpg",
                    Prijs = 39.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "DVD/Blu Ray")
                },
                new Product
                {
                    Artikelnummer = "CM-GH-0805",
                    Artikelnaam = "Crucial 8 GB SODIMM DDR3-1333",
                    Artikelomschrijving = "De Crucial 8 GB SODIMM DDR3-1333-module, is een enkele geheugenmodule " +
                                          " voor gebruik in laptops.Deze heeft een kloksnelheid van 1333 MHz en krijgt" +
                                          " levenslange garantie van Crucial mee.",
                    FiguurURL = @"Content/images/CM-GH-0805.jpg",
                    Prijs = 84.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Geheugen")
                },
                new Product
                {
                    Artikelnummer = "CM-GH-0806",
                    Artikelnaam = "Crucial Apple 16 GB SODIMM DDR3" +
                                  " 1600 Kit van 2",
                    Artikelomschrijving = "Set van 204-pins SODIMM DDR3-geheugenmodules van elk 8 GB die speciaal is" +
                                          " ontwikkeld voor Apple iMacs, Mac Mini's en Apple Macbooks. De Crucial Apple " +
                                          "  heeft een kloksnelheid van 1600 MHz en krijgt levenslange garantie van Crucial" +
                                          "  mee.Let goed op of jouw iMac, Mac Mini of MacBook plaats heeft voor twee" +
                                          " geheugenmodules met een totale maximale grootte van 16 GB.",
                    FiguurURL = @"Content/images/CM-GH-0806.jpg",
                    Prijs = 177.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Geheugen")
                },
                new Product
                {
                    Artikelnummer = "CM-GL-0807",
                    Artikelnaam = "Asus Xonar DX/XD",
                    Artikelomschrijving =
                        "Deze geluidskaart maakt gebruik van Dolby Home Theater technologieën, om een" +
                        " volledige surround ervaring te kunnen bieden. Vocal FX zorgt voor kristalhelder" +
                        " geluid tijdens een online gesprek en tijdens het gamen. Zo heb je niet meer te" +
                        " maken met half verstaanbare gesprekken of games die niet compleet tot hun" +
                        "recht komen. De Asus Xonar geluidskaart levert veel zuiverder geluid dan een" +
                        " onboard geluidskaart." +
                        " Geschikt voor 7.1 en 5.1 speakers of hoofdtelefoons.",
                    FiguurURL = @"Content/images/CM-GL-0807.jpg",
                    Prijs = 74.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Geluidskaarten")
                },
                new Product
                {
                    Artikelnummer = "CM-GL-0808",
                    Artikelnaam = "Asus Xonar Essence STX",
                    Artikelomschrijving =
                        "Deze geluidskaart levert tot wel 64 keer zuiverder geluid dan een onboard ge-" +
                        " luidskaart. Dit lukt de Xonar Essence dankzij het gebruik van componenten van" +
                        " enorm hoge kwaliteit. Zo beschikt de geluidskaart over Nichicon \"Fine Gold\"" +
                        " professionele audio condensatoren en een Burr-Brown PCM 1792A Digital-to-" +
                        "  Analog Convertor. Hierdoor krijgt deze geluidskaart zijn zuiver geluid met rijke" +
                        "  bass en hoge frequenties. Is geschikt voor 7.1 en 5.1 speakers of hoofdtelefoons" +
                        "  en maakt gebruik van Dolby Home Theater technologieën.  ",
                    FiguurURL = @"Content/images/CM-GL-0808.jpg",
                    Prijs = 164.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Geluidskaarten")
                },
                new Product
                {
                    Artikelnummer = "CM-HD-0809",
                    Artikelnaam = "Seagate Barracuda ST4000DM000 4 TB",
                    Artikelomschrijving =
                        "Seagate is al sinds 1979 actief in de harddisk-branche en staat nog steeds vooraan" +
                        " bij nieuwe ontwikkelingen op het gebied van harde schijven. De 3,5 inch Seagate" +
                        " Barracuda van 4 TB is stil. Dankzij een cache van 64 MB en een rotatiesnelheid" +
                        " van 5900 rpm is deze Seagate harde schijf bovendien snel. De snelheid en opslag-" +
                        " capaciteit maken de Barracuda bijzonder geschikt voor high-end computers en" +
                        "  kleine servers zoals NAS en DAS",
                    FiguurURL = @"Content/images/CM-HD-0809.jpg",
                    Prijs = 189M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Harde schijven")
                },
                new Product
                {
                    Artikelnummer = "CM-HD-0810",
                    Artikelnaam = "WD Blue WD7500LPCX 750 GB",
                    Artikelomschrijving =
                        "Deze WD Blue-harde schijf heeft het 2,5 inch-formaat en biedt goede prestaties" +
                        " wat betreft geluid en temperatuur. Omdat de schijf maar 7 mm dik is, past deze" +
                        " zelfs in de dunste laptops. Deze koele, dunne 2,5 inch harde schijf is o.a. geschikt" +
                        " voor ultrabooks en netbooks. Laag energieverbruik vergeleken met 3,5 inch" +
                        "  harde schijven. No Touch Ramp Load-technologie zorgt voor minder slijtage.",
                    FiguurURL = @"Content/images/CM-HD-0810.jpg",
                    Prijs = 95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Harde schijven")
                },
                new Product
                {
                    Artikelnummer = "CM-MB-0811",
                    Artikelnaam = "Asrock 970 Extreme 4",
                    Artikelomschrijving = "De Asrock 970 Extreme4 is een ATX moederbord met een Socket AM3+. " +
                                          "Dankzij de UEFI-Bios pas je gemakkelijk instellingen aan direct vanuit Windows." +
                                          " Dankzij AMD Quad CrossfireX en NVIDIA SLI, sluit je maximaal 4 AMD- of 2" +
                                          " NVIDIA-videokaarten aan. De digitale PWM zorgt voor een zeer stabiel voltage" +
                                          " van de processor-Vcore. Hierdoor is de Asrock 970 Extreme4 zeer goed" +
                                          " overclockbaar. Zodra je de App Charger-driver installeert laadt je mobiele" +
                                          "  apparatuur tot wel 40% sneller op. Dit werkt zelfs als jouw pc uitgeschakeld is." +
                                          " Door THX TruStudio geniet je van een kristalhelder geluid. Bovendien is het" +
                                          "  mogelijk om jouw harde schijven in een RAID-opstelling te gebruiken.",
                    FiguurURL = @"Content/images/CM-MB-0811.jpg",
                    Prijs = 87.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Moederborden")
                },
                new Product
                {
                    Artikelnummer = "CM-MB-0812",
                    Artikelnaam = "Gigabyte GA-Z87X-OC Force",
                    Artikelomschrijving = "Het Gigabyte overclocker moederbord met E-ATX afmetingen heeft een Socket" +
                                          " 1150 en een Intel Z87-chipzet. De Gigabyte Force heeft 4 DDR3-sloten die dual" +
                                          " channel ondersteunen tot maximaal 32 GB aan geheugen kwijt kunnen. Het" +
                                          "  moederbord heeft plaats voor meerdere videokaarten die samen werken via" +
                                          "  AMD Crossfire en Nvidia SLI. Dit moederbord van Gigabyte heeft een stille in-" +
                                          " gebouwde ventilator die zorgt voor uitstekende warmteafvoer tijdens extreme" +
                                          "  configuraties. Dit moederbord heeft 10 SATA-600 aansluitingen en 10 USB 3.0" +
                                          " aansluitingen. Mocht je ooit last hebben van stroomuitval of een mislukte bios-" +
                                          "  update, dan heb je de optie om de backup-bios te activeren.",
                    FiguurURL = @"Content/images/CM-MB-0812.jpg",
                    Prijs = 399.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Moederborden")
                },
                new Product
                {
                    Artikelnummer = "CM-CP-0814",
                    Artikelnaam = "Intel Core i7 3930 K",
                    Artikelomschrijving =
                        "De Intel Core beschikt over 6-Core technologie, maar liefst 12 MB cache en een" +
                        " kloksnelheid van 3.2. GHz die tijdens zware taken verhoogd kan worden tot 3.8" +
                        " GHz. Deze eigenschappen maken hem geschikt voor extreem veeleisende com-" +
                        " putergebruikers zoals gamers en mensen die multitasken met veeleisende pro-" +
                        "  gramma's. Alsof dat nog niet genoeg is heeft de Core i7 3930K een ge-unlockede" +
                        "  multiplier zodat je zelfs deze extreem krachtige processor nog kunt overklokken.",
                    FiguurURL = @"Content/images/CM-CP-0814.jpg",
                    Prijs = 529.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Processoren")
                },
                new Product
                {
                    Artikelnummer = "CM-VC-0815",
                    Artikelnaam = "MSI FX5500-D256H AGP",
                    Artikelomschrijving = "Deze kaart is voorzien van 256 MB DDR3 geheugen, voldoende voor multimedia" +
                                          " doeleinden en het spelen van een game in standaard resolutie. Met deze kaart" +
                                          " kan je twee monitoren los van elkaar gebruiken, zo verhoog je de productiviteit" +
                                          " of geniet je gewoon van meer desktop ruimte. Deze videokaart heeft een pas-" +
                                          " sieve koeling, kan je goed belasten en het maximale uit je systeem halen." +
                                          " Let op: deze videokaart wordt via het AGP-slot met het moederbord verbonden" +
                                          " en dus niet via PCI - express.",
                    FiguurURL = @"Content/images/CM-VC-0815.jpg",
                    Prijs = 44.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Video & TV-kaarten")
                },
                new Product
                {
                    Artikelnummer = "CM-VC-0816",
                    Artikelnaam = "MSI N780 Lightning",
                    Artikelomschrijving =
                        "De MSI N780 Lightning is gebaseerd op de zeer krachtige Nvidia GeForce GTX 780" +
                        " chipset en beschikt over 3072 MB GDDR5 geheugen dat via een 384 bit geheugen-" +
                        " bus aangesproken wordt. De videokaart is voorzien van hoogwaardige onderde-" +
                        " len die militair gecertificeerd zijn. Dit maakt deze zeer geschikt voor over-" +
                        " clocking. De grafische processor heeft een kloksnelheid van 980 MHz die tijdens" +
                        " zware grafische applicaties  dankzij Nvidia GPU Boost 2.0 zelfs opgevoerd wordt" +
                        "  tot 1033 MHz. Om hitte tegen te gaan beschikt deze over de TriFrozr koeler met" +
                        " 3 ventilatoren. Met deze videokaart speel je de nieuwste games in hoge resolu-" +
                        "   tie en kan je voor de beste game-ervaring tot 4 monitoren aansluiten.",
                    FiguurURL = @"Content/images/CM-VC-0816.jpg",
                    Prijs = 659.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Video & TV-kaarten")
                },
                new Product
                {
                    Artikelnummer = "CM-PS-0817",
                    Artikelnaam = "Corsair Builder CX430",
                    Artikelomschrijving = "De Corsair Builder CX430 is een ATX voeding met een vermogen van 430 watt." +
                                          " Tegelijkertijd heeft de voeding een 80 PLUS certificaat waardoor hij behoorlijk" +
                                          " energie-efficiënt is. Ook beschikt de CX430 over extra kabels zodat je hem in een" +
                                          " grote computerkast kunt gebruiken.",
                    FiguurURL = @"Content/images/CM-PS-0817.jpg",
                    Prijs = 49.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Voedingen")
                },
                new Product
                {
                    Artikelnummer = "CM-PS-0818",
                    Artikelnaam = "Corsair HX1050",
                    Artikelomschrijving = "Deze modulaire ATX voeding heeft een vermogen van 1050 watt. Omdat de" +
                                          " Corair HX1050 modulair is, heb je alleen kabels in je computerkast hangen die je" +
                                          " daadwerkelijk gebruikt. Daardoor oogt je computer netter en wordt de airflow" +
                                          " verbeterd. De voeding beschikt over extra lange kabels zodat je hem ook in een" +
                                          " grote computerkast kunt gebruiken. De goede prestaties, stille 140 mm koeler" +
                                          " en vele aansluitmogelijkheden maken hem geschikt voor gamers en veel-" +
                                          " eisende computergebruikers ",
                    FiguurURL = @"Content/images/CM-PS-0818.jpg",
                    Prijs = 189.95M,
                    Categorie = context.Categorieen.Single(c => c.Categorienaam == "Voedingen")
                }
            );

            context.Roles.AddOrUpdate(r => r.Name,
                new Role { RoleId = 1, Name = "klant" },
                new Role { RoleId = 2, Name = "leverancier" },
                new Role { RoleId = 3, Name = "anderePersoon" },
                new Role { RoleId = 4, Name = "administrator" }
            );

            context.SaveChanges();

            var sha = new SHA512CryptoServiceProvider();
            string ivanPassHash = Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes("ivodocent")));
            string paulPassHash = Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes("ivocursist")));
            string administratorPasshash =
                Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes("ivocursist#123")));

            context.User.AddOrUpdate(u => u.Gebruikersnaam,
                new User
                {
                    Gebruikersnaam = "Ivan",
                    PaswoordHash = ivanPassHash,
                    Roles = new List<Role> {
                        context.Roles.Where(r => r.RoleId == 1).First(),
                        context.Roles.Where(r => r.RoleId == 2).First(),
                        context.Roles.Where(r => r.RoleId == 3).First(),
                        context.Roles.Where(r => r.RoleId == 4).First()}

                },
                new User
                {
                    Gebruikersnaam = "Paul",
                    PaswoordHash = paulPassHash,
                    Roles = new List<Role> {
                        context.Roles.Where(r => r.RoleId == 1).First()}
                },
                new User
                {
                    Gebruikersnaam = "administrator",
                    PaswoordHash = administratorPasshash,
                    Roles = new List<Role> {
                        context.Roles.Where(r => r.RoleId == 4).First()}
                }
            );


        }
    }
}
