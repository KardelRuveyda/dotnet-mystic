# Mystic 🔮

This project creates a user interface using Blazor and a backend structure using ASP.NET Core. It applies the RAG (Retrieval-Augmented Generation) method by leveraging the GPT model through OpenAI's Dotnet API and provides dream interpretations using data from a JSON file.

## Project Flow

### 1. Frontend (Blazor)
**Technology:** Blazor WebAssembly or Blazor Server  
**Purpose:** To create an interface where users can write their dreams and see the interpretation results on the screen.  
**Steps:**  
- Create a text box where the dream can be written and a "Interpret" button.
- Set up a field to display the interpretation results.

### 2. Backend (ASP.NET Core API)
**Technology:** ASP.NET Core Web API  
**Purpose:** To process the dream data submitted by users and send it to the GPT model via the OpenAI API to get a response.  
**Steps:**  
- Create API endpoints.
- Integrate the OpenAI API to send requests to the GPT model and return the results.

### 3. Data Processing (RAG - Retrieval-Augmented Generation)
**Method:** RAG (Retrieval-Augmented Generation)  
**Purpose:** To use the JSON file, which contains 100 dream data entries, match it with the user's dream data, and send the most appropriate prompts to GPT. (The data can also be expanded.)  
**Steps:**  
- Read and process the JSON data.
- Match the user's dream with the data in the JSON file.
- Generate a prompt from the collected data to send to GPT.

### 4. OpenAI API (GPT Integration)
**Technology:** OpenAI API (Dotnet OpenAI API)  
**Purpose:** To ask the GPT model for dream interpretations and retrieve the results.  
**Steps:**  
- Create a prompt that contains the user's dream and the data from the JSON file.
- Send this prompt to GPT via the OpenAI API and get the response.

### 5. Data Management (JSON)
**Technology:** JSON  
**Purpose:** To provide the 100 dream interpretation data entries to GPT using the RAG structure.  
**Steps:**  
- Process the JSON file on the backend to prepare the data to be used in the RAG process.

### 6. Displaying Results
**Technology:** Blazor (Frontend)  
**Purpose:** To display the interpretation results from the OpenAI API to the user.  
**Steps:**  
- Display the results received from the backend on the Blazor interface.

### 7. Testing and Optimization
**Method:** Performance and accuracy analysis  
**Purpose:** To ensure that both the frontend and backend are working correctly and to improve the accuracy of the RAG method.  
**Steps:**  
- Test the entire process by running Blazor and ASP.NET Core together.
- Optimize the prompts sent to GPT and the JSON data.

## Requirements
- .NET SDK 6.0 or higher
- Blazor WebAssembly or Server
- ASP.NET Core Web API
- OpenAI API Key
- JSON File (containing 100 dream interpretation entries)

## Usage

- The user writes their dream interpretation request through the Blazor interface.
- The backend matches this data with the dreams in the JSON file.
- A request is made to the GPT model via the OpenAI API, and the results are returned.
- The results are displayed to the user in the Blazor interface.


![image](https://github.com/user-attachments/assets/c3b8423a-7702-4358-8a14-55281b96778b)
