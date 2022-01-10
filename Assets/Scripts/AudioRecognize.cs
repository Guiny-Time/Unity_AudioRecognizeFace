using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class AudioRecognize : MonoBehaviour
{
    public Animator girl;

    public Text wordText;
    // public Text girlText;
    // 语音识别关键字
    public string[] keywords = {"a", "e", "i", "o", "u","早上好","晚安"};
    // 识别可信度
    public ConfidenceLevel m_confidenceLevel = ConfidenceLevel.Medium;
    // 短语识别器
    private PhraseRecognizer m_PhraseRecognizer;

    // Start is called before the first frame update
    void Start()
    {
        if (m_PhraseRecognizer == null)
        {
            //创建一个识别器
            m_PhraseRecognizer = new KeywordRecognizer(keywords, m_confidenceLevel);
            //通过注册监听的方法
            m_PhraseRecognizer.OnPhraseRecognized += M_PhraseRecognizer_OnPhraseRecognized;
            //开启识别器
            m_PhraseRecognizer.Start();
          
            Debug.Log("创建识别器成功");
        }
    }
    /// <summary>
    ///  当识别到关键字时，会调用这个方法
    /// </summary>
    /// <param name="args"></param>
    private void M_PhraseRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        SpeechRecognition(args.text);
        print(args.text);
    }
    private void OnDestroy()
    {
        //判断场景中是否存在语音识别器，如果有，释放
        if (m_PhraseRecognizer != null)
        {
            //用完应该释放，否则会带来额外的开销
            m_PhraseRecognizer.Dispose();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 识别到语音的操作
    /// </summary>
    void SpeechRecognition(string msg)
    {
        switch (msg)
        {
            case "a":
                girl.CrossFade("a", 0.02f);
                wordText.text = "a";
                break;
            case "e":
                girl.CrossFade("e", 0.02f);
                wordText.text = "e";
                break;
            case "i":
                girl.CrossFade("i", 0.02f);
                wordText.text = "i";
                break;
            case "o":
                girl.CrossFade("o", 0.02f);
                wordText.text = "o";
                break;
            case "u":
                girl.CrossFade("u", 0.02f);
                wordText.text = "u";
                break;
            case "早上好":
                girl.CrossFade("morning", 0.02f);
                wordText.text = "早上好";
                break;
            case "晚安":
                girl.CrossFade("evening", 0.02f);
                wordText.text = "晚安";
                break;
        }
    }  
}
