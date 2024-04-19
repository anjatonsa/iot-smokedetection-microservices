from flask import Flask, jsonify, request 
import grpc
import service_pb2
import service_pb2_grpc
from google.protobuf.json_format import MessageToDict
from google.protobuf import empty_pb2
from flask_swagger_ui import get_swaggerui_blueprint
from datetime import datetime
import calendar

app = Flask(__name__) 

SWAGGER_URL = '/api/docs'
API_URL = '/static/swagger.json'

@app.route('/')
def hello_world():
    return '<h1>Hello world!</h2>'

@app.route('/get/<path:id>', methods = ['GET']) 
def get(id): 
    id=int(id)
    try:
        
        with grpc.insecure_channel('grpc-service:8080') as channel:
            stub = service_pb2_grpc.CRUDServiceStub(channel)
            grpc_request = service_pb2.MeasurementId(UID=id)
            grpc_response = stub.Read(grpc_request)
            response=MessageToDict(grpc_response, including_default_value_fields=True)
            print(grpc_response)
        return jsonify(response)
    except Exception as e:
        return jsonify({'errr': f"Error: {e}"})

@app.route('/getall', methods = ['GET']) 
def getAll(): 
    try:
        with grpc.insecure_channel('grpc-service:8080') as channel:
            stub = service_pb2_grpc.CRUDServiceStub(channel)
            grpc_response = stub.ReadAll(empty_pb2.Empty())
            response=MessageToDict(grpc_response, including_default_value_fields=True)
        return jsonify(response)
    except Exception as e:
        return jsonify({'errr': f"Error: {e}"})

@app.route('/create', methods = ['POST']) 
def create():
    data= request.get_json() 
    try:
        with grpc.insecure_channel('grpc-service:8080') as channel:
            stub = service_pb2_grpc.CRUDServiceStub(channel)
            grpc_response = stub.Create(service_pb2.Measurement(
                UID=data["UID"],
                Temperature=data["Temperature"],
                Humidity=data["Humidity"],
                TVOC=data["TVOC"],
                eCO2=data["eCO2"],
                RawH2=data["RawH2"],
                RawEthanol=data["RawEthanol"],
                Pressure=data["Pressure"],
                PM10=data["PM10"],
                PM25=data["PM25"],
                NC05=data["NC05"],
                NC10=data["NC10"],
                NC25=data["NC25"],
                FireAlarm=data["FireAlarm"],
                Timestamp={"seconds": calendar.timegm(datetime.now().utctimetuple())}

            ))
            response=MessageToDict(grpc_response, including_default_value_fields=True)
        return jsonify(response)
    except Exception as e:
        return jsonify({'errr': f"Error: {e}"})

@app.route('/update/<path:id>', methods = ['PUT']) 
def update(id): 
    data = request.get_json()
    print(data)
    id=int(id)
    try:
        with grpc.insecure_channel('grpc-service:8080') as channel:
            stub = service_pb2_grpc.CRUDServiceStub(channel)
            grpc_response = stub.Update(service_pb2.Measurement(
                UID=id,
                Temperature=data["Temperature"],
                Humidity=data["Humidity"],
                TVOC=data["TVOC"],
                eCO2=data["eCO2"],
                RawH2=data["RawH2"],
                RawEthanol=data["RawEthanol"],
                Pressure=data["Pressure"],
                PM10=data["PM10"],
                PM25=data["PM25"],
                NC05=data["NC05"],
                NC10=data["NC10"],
                NC25=data["NC25"],
                FireAlarm=data["FireAlarm"],
                Timestamp={"seconds": calendar.timegm(datetime.now().utctimetuple())}
            ))
            print("res" , grpc_response)
            response=MessageToDict(grpc_response, including_default_value_fields=True)
        return jsonify(response)
    except Exception as e:
        return jsonify({'errr': f"Error: {e}"})

@app.route('/delete/<path:id>', methods = ['DELETE']) 
def delete(id): 
    id=int(id)
    try:
        with grpc.insecure_channel('grpc-service:8080') as channel:
            stub = service_pb2_grpc.CRUDServiceStub(channel)
            grpc_request = service_pb2.MeasurementId(UID=id)
            grpc_response = stub.Delete(grpc_request)
            response=MessageToDict(grpc_response, including_default_value_fields=True)
        return jsonify(response)
    except Exception as e:
        return jsonify({'errr': f"Error: {e}"})



# @app.route('/aggregation', methods = ['GET']) 
# def aggregation(): 
#     try:
#         with grpc.insecure_channel('localhost:5138') as channel:
#             stub = service_pb2_grpc.CRUDServiceStub(channel)
#             grpc_response = stub.SumValue(service_pb2.AggregationParam(
#                 StartTime={"seconds": 1654733332},
#                 EndTime={ "seconds": 1654733339},
#                 DataField="Pressure"
#             ))
#             response=MessageToDict(grpc_response, including_default_value_fields=True)
#         return jsonify(response)
#     except Exception as e:
#         return jsonify({'errr': f"Error: {e}"})



swaggerui_blueprint = get_swaggerui_blueprint(
    SWAGGER_URL, 
    API_URL,
    config={  
        'app_name': "Smoke Detection"
    },
)

app.register_blueprint(swaggerui_blueprint)


if __name__ == '__main__': 
	app.run() 
