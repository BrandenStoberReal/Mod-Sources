using BrandensMod.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BrandensMod.Items.Weapons.Guns.DebugGun
{
    class DebugGun : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("You shouldn't have this...");
		}

		public override void SetDefaults()
		{
			item.damage = 240; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 66; // hitbox width of the item
			item.height = 28; // hitbox height of the item
			item.useTime = 5; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 5; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 15; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = 10000; // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Expert; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item11; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ModContent.ProjectileType<DebugProjectile>(); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 40f; // the speed of the projectile (measured in pixels per frame)
		}
	}
}
