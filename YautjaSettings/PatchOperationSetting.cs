using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Verse;

namespace YautjaSettings
{
    internal class PatchOperationSetting : PatchOperation
    {
        private PatchOperation active;
        public string setting;

        protected virtual bool ApplyWorker(XmlDocument xml)
        {
            if (this.setting == "disableHarClothingRestrictions")
            {
                if (Yautja_Settings.disableHarClothingRestrictions && this.active != null)
                    return this.active.Apply(xml);
            }
            else if (this.setting == "gauntletExplosionToggle")
            {
                if (Yautja_Settings.gauntletExplosionToggle && this.active != null)
                    return this.active.Apply(xml);
            }
            else if (this.setting == "friendlyYautjaFactions")
            {
                if (Yautja_Settings.friendlyYautjaFactions && this.active != null)
                    return this.active.Apply(xml);
            }
            else if (this.setting != null)
                Log.Error("A patch is using a setting that is either mispelled or unhandled");
            else
                Log.Error("A patch is using this mod's settings, but doesn't specify which one.");
            return true;
        }
    }
}
