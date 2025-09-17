from fastapi import FastAPI
from pydantic import BaseModel
from starlette.responses import PlainTextResponse

app = FastAPI()

class Message(BaseModel):
    msg: str



@app.post("/", response_class=PlainTextResponse)
async def create_message(message: Message):
    return f"Server received message:\n{message.msg}"