using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class AudioRecognize : MonoBehaviour
{
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
        SpeechRecognition();
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
    void SpeechRecognition()
    {
       
    }  
}