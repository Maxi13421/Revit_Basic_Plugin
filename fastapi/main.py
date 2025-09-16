from fastapi import FastAPI
from pydantic import BaseModel

app = FastAPI()

class Message(BaseModel):
    msg: str



@app.post("/")
async def create_message(message: Message):
    return f"Received your message: {message.msg}"