using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using System.Threading.Tasks;

namespace Game.AI
{
    /// <summary>
    /// [WIP] ChatGPT Manager 
    /// </summary>
    public class ChatGPTManager : MonoBehaviour
    {
        /// <summary>
        /// Route to the key for OpenAI
        /// </summary>
        private const string DIRECTORY = "D:/Repository/Assets/ChatGPT/Keys";

        /// <summary>
        /// Reference for the connection with ChatGPT
        /// </summary>
        private OpenAIClient _connectionApi;


        private void Awake()
        {
            _connectionApi = new OpenAIClient(OpenAIAuthentication.LoadFromDirectory(DIRECTORY));
            
            if(_connectionApi == null)
            {
                Debug.LogError("Connection cannot be established with ChatGPT");
                return;
            }

            // [TESTING] Getting list of models
            //Task.Run(() => 
            //{ 
            //    GetModelsAsync(); 
            //});
        }


        /// <summary>
        /// Get list of available models
        /// </summary>
        /// <returns></returns>
        private async Task GetModelsAsync() 
        {
            var models = await _connectionApi.ModelsEndpoint.GetModelsAsync();

            foreach (var model in models)
            {
                Debug.Log(model.ToString());
            }

        }
    }
}