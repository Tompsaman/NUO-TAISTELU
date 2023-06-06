using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

namespace NUO_TAISTELU;

public class NUO_TAISTELU : PhysicsGame
{
    public override void Begin()
    {
        PhysicsObject Kortti = new PhysicsObject(170, 240);
        
        Kortti.X = Kortti.X - 40;
        Kortti.Y = Kortti.Y - 350;
        
        Kortti.Color = Color.Red;
        Add(Kortti);
        
        PhysicsObject Kortti2 = new PhysicsObject(170, 240);
        
        Kortti2.X = Kortti2.X + 200;
        Kortti2.Y = Kortti2.Y - 350;
        
        Kortti2.Color = Color.Red;
        Add(Kortti2);
        
        PhysicsObject Kortti3 = new PhysicsObject(170, 240);
        
        Kortti3.X = Kortti3.X + 440;
        Kortti3.Y = Kortti3.Y - 350;
        
        Kortti3.Color = Color.Red;
        Add(Kortti3);
        
        PhysicsObject Kortti4 = new PhysicsObject(170, 240);
        
        Kortti4.X = Kortti4.X + 680;
        Kortti4.Y = Kortti4.Y - 350;
        
        Kortti4.Color = Color.Red;
        Add(Kortti4);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
        
        
    }
    
    
}