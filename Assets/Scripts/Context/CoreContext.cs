using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.signal.impl;
using UnityEditor;
using UnityEngine;

namespace context
{
    public abstract class CoreContext : MVCSContext
    {
        protected CoreContext(MonoBehaviour view) : base(view)
        {
        }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        public override IContext Start()
        {
            base.Start();
            var startSignal = GetStartSignalInstance();
            startSignal.Dispatch();
            return this;
        }

        protected override void mapBindings()
        {
            if (firstContext == this) MapAsIndependentContext();
            else MapAsModuleContext();
            MapEntities();
            MapSignals();
            MapMediators();
        }

        protected abstract Signal GetStartSignalInstance();

        protected virtual void MapEntities()
        {
        }

        protected virtual void MapSignals()
        {
        }

        protected virtual void MapMediators()
        {
        }

        protected abstract void MapAsIndependentContext();
        protected abstract void MapAsModuleContext();

#if UNITY_EDITOR
        [MenuItem("MyCategory/Clear Lods")]
        static void ClearLods()
        {
            var selection = Selection.gameObjects;
            foreach (var item in selection)
            {
                var childs = item.GetComponentsInChildren<MeshRenderer>(true);

                foreach (var r in childs)
                {
                    r.receiveShadows = false;
                    r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    r.receiveGI = ReceiveGI.Lightmaps;
                }

                childs[0].gameObject.SetActive(false);
                childs[1].gameObject.SetActive(true);
                childs[2].gameObject.SetActive(true);

                var lodGroupd = item.GetComponent<LODGroup>();
                lodGroupd.fadeMode = LODFadeMode.SpeedTree;
                lodGroupd.animateCrossFading = false;
                var lod1 = new LOD
                {
                    renderers = new Renderer[] { childs[1] },
                    screenRelativeTransitionHeight = 0.1f,
                };
                var lod2 = new LOD
                {
                    renderers = new Renderer[] { childs[2] },
                    screenRelativeTransitionHeight = 0.05f,
                };
                var lods = new LOD[] { lod1, lod2 };
                lodGroupd.SetLODs(lods);
                item.SetActive(true);

                //var newCol = childs[1].gameObject.AddComponent<MeshCollider>();
                //newCol.convex = true;
                //newCol.sharedMesh = childs[1].GetComponent<MeshFilter>().mesh;
            }
        }
#endif
    }
}
