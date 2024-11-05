from fastapi import FastAPI, File, UploadFile, HTTPException
from fastapi.responses import JSONResponse
from tensorflow.keras.models import load_model
from tensorflow.keras.preprocessing import image
import numpy as np
from PIL import Image
import io
app = FastAPI()
model = load_model("pneumonia_classifier_model.keras")
def preprocess_image(img):
    if img.mode != 'RGB':
        img = img.convert('RGB')
    img = img.resize((150, 150))  
    img_array = image.img_to_array(img)  
    img_array = np.expand_dims(img_array, axis=0) 
    img_array = img_array / 255.0  
    return img_array
@app.post("/predict")
async def predict(file: UploadFile = File(...)):
    if not file.content_type.startswith('image/'):
        raise HTTPException(status_code=400, detail="Invalid file type. Please upload an image.")
    try:
        contents = await file.read()
        img = Image.open(io.BytesIO(contents))
        img = preprocess_image(img)
        predictions = model.predict(img)
        probability = predictions[0][0]
        diagnosis = "PNEUMONIA" if probability > 0.5 else "NORMAL"
        return JSONResponse({
            "diagnosis": diagnosis,
            "probability": float(probability)
        })
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))
# Command: uvicorn app:app --reload
