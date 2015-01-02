using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using TAPI;
using Terraria;


namespace tcfcomm
{
    public sealed class MPlayer : ModPlayer
    {
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void MidUpdate()
        { /*
            if (player.inventory[player.selectedItem].type == ItemDef.byName["jComm:FLAILNAME"].type)
            {
                Main.chain3Texture = MBase.BaseInstance.textures["Images/SOMETHING Chain"]; //changes texture of chain3 if player is holding correct flail, defined above
            } */
            if (player.armor[0].type == ItemDef.byType[894].type && player.armor[1].type == ItemDef.byType[895].type && player.armor[2].type == ItemDef.byType[896].type)
            {
                player.thorns = 0.28f;
                player.setBonus = "Grants player minor contact damage";
                player.statDefense -= 1;
            } //gives player a lesser thorns effect when using cactus armour
        }
    }
}