using Entitas;
using UnityEngine;
public interface IViewService {
    void LoadAsset(Contexts contexts, IEntity entity, string assetName, Transform parent);
}