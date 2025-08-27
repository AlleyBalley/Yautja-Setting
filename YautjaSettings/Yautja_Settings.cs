using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace YautjaSettings
{
    public class Yautja_Settings : ModSettings
    {
        public static bool disableHarClothingRestrictions = false;
        public static bool friendlyYautjaFactions = false;
        public static bool gauntletExplosionToggle = true;
        public float gauntletExplosionRadius = 3f;

        public virtual void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<bool>(ref Yautja_Settings.disableHarClothingRestrictions, "disableHarClothingRestrictions", false, false);
            Scribe_Values.Look<bool>(ref Yautja_Settings.friendlyYautjaFactions, "friendlyYautjaFactions", false, false);
            Scribe_Values.Look<bool>(ref Yautja_Settings.gauntletExplosionToggle, "gauntletExplosionToggle", true, false);
            Scribe_Values.Look(ref this.gauntletExplosionRadius, "gauntletExplosionRadius", 4f);
        }

        public class YautjaSettings : Mod
        {
            Yautja_Settings settings;

            public YautjaSettings(ModContentPack content) : base(content)
            {
                this.settings = GetSettings<Yautja_Settings>();
            }
            public override string SettingsCategory() => "Xenotype Yautja Settings";

            public override void DoSettingsWindowContents(Rect inRect)
            {
                Listing_Standard listingStandard = new Listing_Standard();
                listingStandard.Begin(inRect);
                listingStandard.CheckboxLabeled("disableHarClothingRestrictions", ref Yautja_Settings.disableHarClothingRestrictions);
                listingStandard.CheckboxLabeled("gauntletExplosionToggle", ref Yautja_Settings.gauntletExplosionToggle);
                listingStandard.CheckboxLabeled("friendlyYautjaFactions", ref Yautja_Settings.friendlyYautjaFactions);
                listingStandard.Label("gauntletExplosionRadius");
                this.settings.gauntletExplosionRadius = Widgets.HorizontalSlider(inRect.BottomHalf().TopHalf(), this.settings.gauntletExplosionRadius, 1f, 10f, true, "Size of explosion: " + this.settings.gauntletExplosionRadius + "\nDetermines the size of yautja gauntlet self-destruction", "1 tile", "10 tiles");
                listingStandard.End();
                base.DoSettingsWindowContents(inRect);

                this.settings.Write();
            }
        }
    }
}
