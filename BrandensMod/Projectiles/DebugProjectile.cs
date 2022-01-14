using System; //what sources the code uses, these sources allow for calling of terraria functions, existing system functions and microsoft vector functions (probably more)
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BrandensMod.Projectiles //where it's stored, replace Mod with the name of your mod. This file is stored in the folder \Mod Sources\(mod name, folder can't have spaces)\Projectiles.
{
    public class DebugProjectile : ModProjectile //the class of the projectile. Change ProjectileSkeleton to whatever you want the projectile name to be.
    {
        public override void SetDefaults()
        {
            projectile.width = 48; //sprite is 48 pixels wide
            projectile.height = 8; //sprite is 8 pixels tall
            projectile.aiStyle = 0; //projectile moves in a straight line
            projectile.friendly = true; //player projectile
            projectile.ranged = true; //ranged projectile
            projectile.timeLeft = 360; //lasts for 600 frames/ticks. Terraria runs at 60FPS, so it lasts 10 seconds.
            projectile.tileCollide = false; //Go through wall
            aiType = ProjectileID.EyeBeam; //This clones the exact AI of the vanilla projectile Bullet.
            projectile.penetrate = 10;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.ShadowFlame, damage * 100);
            Player player = Main.player[projectile.owner];
            if (player.statLife < player.statLifeMax2)
            {
                player.statLife += damage / 2;
                player.HealEffect(damage / 2); // Heal indicator
            }
            //target.velocity = new Vector2(15, -10); // Shoot into air?
        }

        public override void AI()
        {
            Random Offset = new Random();

            Lighting.AddLight(projectile.position, 1f, 0f, 1f);
            Dust.NewDust(projectile.position + new Vector2(Offset.Next(5, 15), Offset.Next(5, 10)), projectile.width, projectile.height, DustID.Shadowflame);
            projectile.rotation = projectile.velocity.ToRotation();

            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];                
                
                //If the npc is hostile, not immortal, and not a dummy
                if (!target.friendly && target.immortal == false && target.dontTakeDamage == false && target.type != NPCID.TargetDummy)
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 240f && target.active)
                    {
                        //Divide the factor, 9f, which is the desired velocity
                        distance = 6f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                }
            }
        }
    }
}