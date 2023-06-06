using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

namespace NUO_TAISTELU;

public class NUO_TAISTELU : PhysicsGame
{
    Image tausta = LoadImage("tausta");
    Image olionKuva = LoadImage("olionKuva");
    Image viisi = LoadImage("viisi");
    Image failcard = LoadImage("failcard");
    Image kuusi = LoadImage("kuusi");
    Image kahdeksan = LoadImage("kahdeksan");
    public override void Begin()
    {
        Level.Background.Image = tausta;

        PhysicsObject Kortti = new PhysicsObject(170, 240);
        
        Kortti.X = Kortti.X - 140;
        Kortti.Y = Kortti.Y - 350;
        
        Kortti.Color = Color.Red;
        Kortti.Image = kuusi;
        Add(Kortti);
        
        PhysicsObject Kortti2 = new PhysicsObject(170, 240);
        
        Kortti2.X = Kortti2.X + 100;
        Kortti2.Y = Kortti2.Y - 350;
        
        Kortti2.Color = Color.Red;
        Kortti2.Image = failcard;
        Add(Kortti2);
        
        PhysicsObject Kortti3 = new PhysicsObject(170, 240);
        
        Kortti3.X = Kortti3.X + 340;
        Kortti3.Y = Kortti3.Y - 350;
        
        Kortti3.Color = Color.Red;
        Kortti3.Image = kahdeksan;
        Add(Kortti3);
        
        PhysicsObject Kortti4 = new PhysicsObject(170, 240);
        
        Kortti4.X = Kortti4.X + 580;
        Kortti4.Y = Kortti4.Y - 350;
        
        Kortti4.Color = Color.Red;
        Kortti4.Image = viisi;
        Add(Kortti4);
        
        PhysicsObject kasi = new PhysicsObject(270, 480);
        
        kasi.X = kasi.X + 830;
        kasi.Y = kasi.Y - 350;
        
        kasi.Image = olionKuva;

        Add(kasi);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        
        
    }
    
    
}