using UnityEngine;
using UnityEditor;

namespace TDHeart.Editor {

    public static class GameObjectCreationContextMenu {

        [MenuItem("GameObject/UI/TDHeart/UI_Button_White_1", false, 1)]
        public static void UI_Button_White_1() {
            var parent = Selection.activeGameObject?.transform;
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources_Editor/UIPreset/Button_Rect_White_1.prefab");
            var go = GameObject.Instantiate(prefab, parent);
        }

    }

}