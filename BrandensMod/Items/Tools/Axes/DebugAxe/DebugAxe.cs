using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BrandensMod.Items.Tools.Axes.DebugAxe
{
    class DebugAxe : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("You shouldn't have this...");
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			item.melee = true;
			item.width = 62;
			item.height = 56;
			item.useTime = 1;
			item.useAnimation = 5;
			item.axe = 150;          //How much axe power the weapon has, note that the axe power displayed in-game is this value multiplied by 5
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Expert;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
		}
	}
}
