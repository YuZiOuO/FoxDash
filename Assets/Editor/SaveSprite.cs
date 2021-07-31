using UnityEngine;
using UnityEditor;

public class SaveSprite
{

    [MenuItem("Assets/����ѡ��ͼƬΪ����png")]
    static void ExportSelSprite()
    {
        string resourcesPath = "Assets/Resources/";
        foreach (Object obj in Selection.objects)
        {
            string selectionPath = AssetDatabase.GetAssetPath(obj);

            // �������ϼ���"Assets/Resources/"
            if (selectionPath.StartsWith(resourcesPath))
            {
                string selectionExt = System.IO.Path.GetExtension(selectionPath);
                if (selectionExt.Length == 0)
                {
                    continue;
                }

                // �õ�����·��
                string loadPath = selectionPath.Remove(selectionPath.Length - selectionExt.Length);
                loadPath = loadPath.Substring(resourcesPath.Length);

                // ���ش��ļ��µ�������Դ
                Sprite[] sprites = Resources.LoadAll<Sprite>(loadPath);
                if (sprites.Length > 0)
                {
                    // ���������ļ���
                    string outPath = Application.dataPath + "/outSprite/" + loadPath;
                    System.IO.Directory.CreateDirectory(outPath);

                    foreach (Sprite sprite in sprites)
                    {
                        // ��������������
#pragma warning disable IDE0090 // ʹ�� "new(...)"
                        Texture2D tex = new Texture2D((int)sprite.rect.width,(int)sprite.rect.height,sprite.texture.format,false);
#pragma warning restore IDE0090 // ʹ�� "new(...)"
                        tex.SetPixels(sprite.texture.GetPixels((int)sprite.rect.xMin, (int)sprite.rect.yMin,
                            (int)sprite.rect.width, (int)sprite.rect.height));
                        tex.Apply();

                        // д���PNG�ļ�
                        System.IO.File.WriteAllBytes(outPath + "/" + sprite.name + ".png", tex.EncodeToPNG());
                    }
                    Debug.Log(string.Format("Export {0} to {1}", loadPath, outPath));
                }
            }
        }
        Debug.Log("Export All Sprites Finished");
    }
}