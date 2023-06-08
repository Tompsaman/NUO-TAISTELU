using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

namespace NUO_TAISTELU;

public class NUO_TAISTELU : PhysicsGame
{
    private Double EVENT_INTERVAL = 1;
    Image tausta_uusi = LoadImage("tausta_uusi");
    Image olionKuva = LoadImage("olionKuva");
    Image viisi = LoadImage("viisi");
    Image failcard = LoadImage("failcard");
    Image kuusi = LoadImage("kuusi");
    Image kahdeksan = LoadImage("kahdeksan");
    Image ukko = LoadImage("ukko");
    Image NUO = LoadImage("NUO");
    Image nolla = LoadImage("nolla");
    Image phone = LoadImage("phone");
    Image puhe1 = LoadImage("puhe1");
    Image pistooli = LoadImage("pistooli");

    DoubleMeter alaspainlaskuri;
    Timer aikalaskuri;
    private int lasku2 = 1;

    private PhysicsObject kasi;
    private PhysicsObject äijä;
    
    void LuoAikalaskuri()
    {
        alaspainlaskuri = new DoubleMeter(EVENT_INTERVAL);
        
        aikalaskuri = new Timer();
        aikalaskuri.Interval = EVENT_INTERVAL;
        aikalaskuri.Timeout += LaskeAlaspain;
        aikalaskuri.SecondCounterStep = -1;
        aikalaskuri.Start();
        Label aikanaytto = new Label();
        aikanaytto.TextColor = Color.White;
        aikanaytto.DecimalPlaces = 1;
        aikanaytto.BindTo(aikalaskuri.SecondCounter);
        aikanaytto.X = 970;
        aikanaytto.Y = 370;
        Add(aikanaytto, 1);
        
        
    }
    void LaskeAlaspain()
    {
        aikalaskuri.SecondCounter.Reset();
        switch (lasku2)
        {
            case 1:
                kasi.Image = phone;
                break;
            case 2: 
                äijä.Image = puhe1;
                break;
            case 3:
                PhysicsObject ase = new PhysicsObject(100, 160);
        
                ase.X = ase.X - 120;
                ase.Y = ase.Y + 200;
        
                ase.Image = pistooli;

                Add(ase);
                ase.Angle = Angle.FromDegrees(14);
                break;
            case 4:
                var rajahdys = new Explosion(900);
                rajahdys.Position = new Vector(+ 100, - 20);
                rajahdys.UseShockWave = true;
                Add(rajahdys);
                break;
        }
        kasi.Image = phone;
        ukko = puhe1;
        lasku2++;
    }

    private void LuoKentta()
    {
        LuoAikalaskuri();
        
        Level.Background.Image = tausta_uusi;
        Level.Background.ScaleToLevelFull();
        IsFullScreen = true;

        Camera.ZoomToLevel();
        double paikka = - 100;
        LuoKortti(kuusi,paikka);
        double paikkamuutos = 170;
        paikka = paikka + paikkamuutos;
        LuoKortti(failcard,paikka);
        paikka = paikka + paikkamuutos;
        LuoKortti(kahdeksan,paikka);
        paikka = paikka + paikkamuutos;
        LuoKortti(viisi,paikka);
        
        kasi = new PhysicsObject(200, 400);
        
        kasi.X = kasi.X + 600;
        kasi.Y = kasi.Y - 200;
        
        kasi.Image = olionKuva;

        Add(kasi);
        
        äijä = new PhysicsObject(400, 413);
        
        äijä.X = äijä.X + - 400;
        äijä.Y = äijä.Y + 200;
        
        äijä.Image = ukko;

        Add(äijä);
        äijä.Angle = Angle.FromDegrees(14);
        
        PhysicsObject pakka = new PhysicsObject(100, 160);
        
        pakka.X = pakka.X + 250;
        pakka.Y = pakka.Y - 20;
        
        pakka.Image = NUO;

        Add(pakka);
        pakka.Angle = Angle.FromDegrees(14);
        
        PhysicsObject aloitusKortti = new PhysicsObject(100, 160);
        
        aloitusKortti.X = aloitusKortti.X + 100;
        aloitusKortti.Y = aloitusKortti.Y - 55;
        
        aloitusKortti.Image = nolla;

        Add(aloitusKortti);
        aloitusKortti.Angle = Angle.FromDegrees(14);
        
       
    }

    private void LuoKortti(Image image, double paikka)
    {

        PhysicsObject Kortti = new PhysicsObject(100, 160);
        
        Kortti.X =  paikka;
        Kortti.Y =   - 300;
        
        Kortti.Color = Color.Red;
        Kortti.Image = image;
        Add(Kortti);
    }
    public override void Begin()
    {
        LuoKentta();
        
        

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        
        
    }
    
    
}