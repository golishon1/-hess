using UnityEditor;
using UnityEngine;

public class GenerateBoardEditor : EditorWindow
{
    private GenerateBoard _generateBoard;

    private void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);


        _generateBoard =
            (GenerateBoard) EditorGUILayout.ObjectField("Generator", _generateBoard, typeof(GenerateBoard));

        if (GUILayout.Button("Generate")) GenerateBoard();
        if (GUILayout.Button("Clear")) ClearBoards();
    }

    [MenuItem("Chees/Generate")]
    private static void ShowWindow()
    {
        var window = (GenerateBoardEditor) GetWindow(typeof(GenerateBoardEditor));
        window.Show();
    }

    private void ClearBoards()
    {
        _generateBoard.ClearBoards();
    }

    public void GenerateBoard()
    {
        _generateBoard.GenerateCells();
    }
}