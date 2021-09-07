using Code.Editor;
using UnityEditor;
public class MenuItems 
{
    [MenuItem("HWMenu/MenuItem 0")]
            private static void MenuOption()
            {
                EditorWindow.GetWindow(typeof(TestEditorWindow), false, "HWMenu");
            }
    [MenuItem("HWMenu/MenuItem 1")]
            private static void MainMenuOption()
            {
    
            }
    [MenuItem("HWMenu/MenuItem 2")]
            private static void NewMenuOption()
            {
            }
    [MenuItem("HWMenu/MenuItem 3")]
            private static void NewNestedOption()
            {
            }
    
    [MenuItem("HWMenu/MenuItem 4 _o")]
            private static void NewOptionWithHotkey()
            {
            }
    
    [MenuItem("HWMenu/Row/MenuItem _t")]
            private static void NewOptionWithHot()
            {
            }
    
    [MenuItem("Assets/HWMenu")]
            private static void LoadAdditiveScene()
            {
            }
    
    [MenuItem("Assets/Create/HWMenu")]
            private static void AddConfig()
            {
            }
    [MenuItem("CONTEXT/Rigidbody/HWMenu")]
            private static void NewOpenForRigidBody()
            {
            }

}
