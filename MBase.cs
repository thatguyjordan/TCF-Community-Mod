using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using TAPI;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace tcfcomm
{
    public sealed class MBase : ModBase
    {
        internal static MBase BaseInstance;
        public override void OnLoad() 
        {
            BaseInstance = this;
            DateTime now = DateTime.Now;
            int day = now.Day;
            int month = now.Month;
            bool red = now.Day == 12 && now.Month == 11;
            bool jordan = now.Day == 3 && now.Month == 7;
            bool neal = now.Day == 27 && now.Month == 7;
            bool test = now.Day == 1 && now.Month == 11;
/*            bool cireus = now.Day == 0 && now.Month == 0;
            Main.chain3Texture = MBase.BaseInstance.textures["Images/SOMETHING Chain"]; //loads chain texture?
*/          Main.NPCLoaded[4] = true; //loads npc so texture is loaded first time around, not after first encounter with said enemy
            Main.npcTexture[4] = MBase.BaseInstance.textures["Images/Scarecrow/EoC"]; //changes eoc texture to EoC
            if (NPC.downedBoss3 = true) //checks to see whether skeletron has been defeated
            {
                Main.NPCLoaded[35] = true; //loads skeletron head
                Main.npcTexture[35] = MBase.BaseInstance.textures["Images/Scarecrow/SkeleDowned"]; //replaces skele head with skeledowned
                Main.NPCLoaded[36] = true; //same
                Main.npcTexture[36] = MBase.BaseInstance.textures["Images/Scarecrow/SkeleHandDowned"]; //replaces skele hand with skelehanddowned
                Main.boneArmTexture = MBase.BaseInstance.textures["Images/Scarecrow/SkeleBoneDowned"]; //replaces skele hand with skelehanddowned
            }
            if (red || jordan || neal || test) //checks if it is any of the specified dates
            {
                // fuck my codes shit
                Main.NPCLoaded[113] = true; //loads npc so texture is loaded first time around, not after first encounter with said enemy
                Main.NPCLoaded[114] = true;
                Main.NPCLoaded[115] = true;
                Main.NPCLoaded[116] = true;
                Main.NPCLoaded[117] = true; 
                Main.NPCLoaded[118] = true;
                Main.NPCLoaded[119] = true;
                Main.npcTexture[114] = MBase.BaseInstance.textures["Images/Scarecrow/WallEyes"];//changes wall of flesh eyes texture to WallEyes
                Main.npcTexture[113] = MBase.BaseInstance.textures["Images/Scarecrow/WallMouth"]; //changes wall of flesh mouth texture to WallMouth
                Main.npcTexture[115] = MBase.BaseInstance.textures["Images/Scarecrow/Cupcake"]; //changes the hungry texture to Cupcake
                Main.npcTexture[116] = MBase.BaseInstance.textures["Images/Scarecrow/CupcakeF"]; //changes the hungry texture to CupcakeF
                Main.npcTexture[117] = MBase.BaseInstance.textures["Images/Scarecrow/GummyWormHead"]; //changes the hungry texture to GummyWormHead
                Main.npcTexture[118] = MBase.BaseInstance.textures["Images/Scarecrow/GummyWormBody"]; //changes the hungry texture to GummyWormBody
                Main.npcTexture[119] = MBase.BaseInstance.textures["Images/Scarecrow/GummyWormTail"]; //changes the hungry texture to GummyWormTail
                Main.chain12Texture = MBase.BaseInstance.textures["Images/Scarecrow/HungryChain"]; //loads hungry chain texture
                Main.wofTexture = MBase.BaseInstance.textures["Images/Scarecrow/WallOfCake"]; //changes wall of flesh eyes texture to WallEyes
            }
        }
        public override void OnUnload() {
            Main.NPCLoaded[4] = false; //unloads texture, I assume in case of mod removal, or changes in mod?
            Main.NPCLoaded[114] = false; //unloads texture, I assume in case of mod removal, or changes in mod?
//            Main.chain3Texture = MBase.BaseInstance.textures["Images/Chain3"]; //resets back to default chain texture
        }
    }
}