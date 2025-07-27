using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.MathTools;
using Cairo;
using static xSkillGilded.ImGuiUtil;

namespace xSkillGilded {

    public class levelPopup : IRenderer {
        ICoreClientAPI api;

        int TextureId;
        int width = 160;
        int height = 64;

        public levelPopup(ICoreClientAPI api) {
            this.api = api;

            ImageSurface surface = new ImageSurface(Format.Rgb24, width, height);
            Context cr = new(surface);

            cr.LineWidth = 0.1;
            cr.SetSourceColor(new Color(0, 0, 0));
            cr.Rectangle(0.25, 0.25, 0.5, 0.5);
            cr.Stroke();

            LoadedTexture tex = new(api);

            TextureId = resourceLoader.Sprite("meta_spec_selected").TextureId;
        }

        public double RenderOrder => 1;
        public int RenderRange => 0;

        public void OnRenderFrame(float deltaTime, EnumRenderStage stage) {
            
            ElementBounds window = api.Gui.WindowBounds;
            float windowWidth  = (float)window.OuterWidth;
            float windowHeight = (float)window.OuterHeight;

            api.Render.RenderTexture(TextureId, windowWidth / 2 - width / 2, windowHeight / 2 - height / 2, width, height);
        }
        
        public void Dispose() {
            api.Event.UnregisterRenderer(this, EnumRenderStage.Ortho);

        }

    }
}
