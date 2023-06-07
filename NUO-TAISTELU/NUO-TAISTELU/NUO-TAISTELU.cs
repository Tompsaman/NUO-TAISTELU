using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

namespace NUO_TAISTELU;

public class NUO_TAISTELU : PhysicsGame
{
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
    
    DoubleMeter alaspainlaskuri;
    Timer aikalaskuri;
    private int lasku2 = 1;

    private PhysicsObject kasi;
    
    void LuoAikalaskuri()
    {
        alaspainlaskuri = new DoubleMeter(20);
    
        aikalaskuri = new Timer();
        aikalaskuri.Interval = 2;
        aikalaskuri.Timeout += LaskeAlaspain;
        aikalaskuri.Start();
        
        
        
        Label aikanaytto = new Label();
        aikanaytto.TextColor = Color.White;
        aikanaytto.DecimalPlaces = 1;
        aikanaytto.BindTo(alaspainlaskuri);
        aikanaytto.X = 670;
        aikanaytto.Y = 370;
        Add(aikanaytto, 1);
        
        
    }
    void LaskeAlaspain()
    {
        switch (lasku2)
        {
            case 1:
                kasi.Image = phone;
                break;
            case 2:
                ukko.Image = phone;
                break;
        }
        kasi.Image = phone;
        lasku2++;
    }

    private void LuoKentta()
    {
        //Timer ajastin = new Timer();
        //ajastin.Interval = 1.5;
        //ajastin.Timeout += 
        //ajastin.Start();
        
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
        
        PhysicsObject äijä = new PhysicsObject(400, 413);
        
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