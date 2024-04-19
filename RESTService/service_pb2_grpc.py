# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
"""Client and server classes corresponding to protobuf-defined services."""
import grpc

from google.protobuf import empty_pb2 as google_dot_protobuf_dot_empty__pb2
import service_pb2 as service__pb2


class CRUDServiceStub(object):
    """Missing associated documentation comment in .proto file."""

    def __init__(self, channel):
        """Constructor.

        Args:
            channel: A grpc.Channel.
        """
        self.Create = channel.unary_unary(
                '/crudservice.CRUDService/Create',
                request_serializer=service__pb2.Measurement.SerializeToString,
                response_deserializer=service__pb2.Measurement.FromString,
                )
        self.Read = channel.unary_unary(
                '/crudservice.CRUDService/Read',
                request_serializer=service__pb2.MeasurementId.SerializeToString,
                response_deserializer=service__pb2.Measurement.FromString,
                )
        self.ReadAll = channel.unary_unary(
                '/crudservice.CRUDService/ReadAll',
                request_serializer=google_dot_protobuf_dot_empty__pb2.Empty.SerializeToString,
                response_deserializer=service__pb2.Measurements.FromString,
                )
        self.Update = channel.unary_unary(
                '/crudservice.CRUDService/Update',
                request_serializer=service__pb2.Measurement.SerializeToString,
                response_deserializer=service__pb2.Measurement.FromString,
                )
        self.Delete = channel.unary_unary(
                '/crudservice.CRUDService/Delete',
                request_serializer=service__pb2.MeasurementId.SerializeToString,
                response_deserializer=service__pb2.MessageResponse.FromString,
                )
        self.MinValue = channel.unary_unary(
                '/crudservice.CRUDService/MinValue',
                request_serializer=service__pb2.AggregationParam.SerializeToString,
                response_deserializer=service__pb2.AggregationResult.FromString,
                )
        self.MaxValue = channel.unary_unary(
                '/crudservice.CRUDService/MaxValue',
                request_serializer=service__pb2.AggregationParam.SerializeToString,
                response_deserializer=service__pb2.AggregationResult.FromString,
                )
        self.AvgValue = channel.unary_unary(
                '/crudservice.CRUDService/AvgValue',
                request_serializer=service__pb2.AggregationParam.SerializeToString,
                response_deserializer=service__pb2.AggregationResult.FromString,
                )
        self.SumValue = channel.unary_unary(
                '/crudservice.CRUDService/SumValue',
                request_serializer=service__pb2.AggregationParam.SerializeToString,
                response_deserializer=service__pb2.AggregationResult.FromString,
                )


class CRUDServiceServicer(object):
    """Missing associated documentation comment in .proto file."""

    def Create(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def Read(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def ReadAll(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def Update(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def Delete(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def MinValue(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def MaxValue(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def AvgValue(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')

    def SumValue(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')


def add_CRUDServiceServicer_to_server(servicer, server):
    rpc_method_handlers = {
            'Create': grpc.unary_unary_rpc_method_handler(
                    servicer.Create,
                    request_deserializer=service__pb2.Measurement.FromString,
                    response_serializer=service__pb2.Measurement.SerializeToString,
            ),
            'Read': grpc.unary_unary_rpc_method_handler(
                    servicer.Read,
                    request_deserializer=service__pb2.MeasurementId.FromString,
                    response_serializer=service__pb2.Measurement.SerializeToString,
            ),
            'ReadAll': grpc.unary_unary_rpc_method_handler(
                    servicer.ReadAll,
                    request_deserializer=google_dot_protobuf_dot_empty__pb2.Empty.FromString,
                    response_serializer=service__pb2.Measurements.SerializeToString,
            ),
            'Update': grpc.unary_unary_rpc_method_handler(
                    servicer.Update,
                    request_deserializer=service__pb2.Measurement.FromString,
                    response_serializer=service__pb2.Measurement.SerializeToString,
            ),
            'Delete': grpc.unary_unary_rpc_method_handler(
                    servicer.Delete,
                    request_deserializer=service__pb2.MeasurementId.FromString,
                    response_serializer=service__pb2.MessageResponse.SerializeToString,
            ),
            'MinValue': grpc.unary_unary_rpc_method_handler(
                    servicer.MinValue,
                    request_deserializer=service__pb2.AggregationParam.FromString,
                    response_serializer=service__pb2.AggregationResult.SerializeToString,
            ),
            'MaxValue': grpc.unary_unary_rpc_method_handler(
                    servicer.MaxValue,
                    request_deserializer=service__pb2.AggregationParam.FromString,
                    response_serializer=service__pb2.AggregationResult.SerializeToString,
            ),
            'AvgValue': grpc.unary_unary_rpc_method_handler(
                    servicer.AvgValue,
                    request_deserializer=service__pb2.AggregationParam.FromString,
                    response_serializer=service__pb2.AggregationResult.SerializeToString,
            ),
            'SumValue': grpc.unary_unary_rpc_method_handler(
                    servicer.SumValue,
                    request_deserializer=service__pb2.AggregationParam.FromString,
                    response_serializer=service__pb2.AggregationResult.SerializeToString,
            ),
    }
    generic_handler = grpc.method_handlers_generic_handler(
            'crudservice.CRUDService', rpc_method_handlers)
    server.add_generic_rpc_handlers((generic_handler,))


 # This class is part of an EXPERIMENTAL API.
class CRUDService(object):
    """Missing associated documentation comment in .proto file."""

    @staticmethod
    def Create(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/crudservice.CRUDService/Create',
            service__pb2.Measurement.SerializeToString,
            service__pb2.Measurement.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def Read(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/crudservice.CRUDService/Read',
            service__pb2.MeasurementId.SerializeToString,
            service__pb2.Measurement.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def ReadAll(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/crudservice.CRUDService/ReadAll',
            google_dot_protobuf_dot_empty__pb2.Empty.SerializeToString,
            service__pb2.Measurements.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def Update(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/crudservice.CRUDService/Update',
            service__pb2.Measurement.SerializeToString,
            service__pb2.Measurement.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def Delete(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/crudservice.CRUDService/Delete',
            service__pb2.MeasurementId.SerializeToString,
            service__pb2.MessageResponse.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def MinValue(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/crudservice.CRUDService/MinValue',
            service__pb2.AggregationParam.SerializeToString,
            service__pb2.AggregationResult.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def MaxValue(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/crudservice.CRUDService/MaxValue',
            service__pb2.AggregationParam.SerializeToString,
            service__pb2.AggregationResult.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def AvgValue(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/crudservice.CRUDService/AvgValue',
            service__pb2.AggregationParam.SerializeToString,
            service__pb2.AggregationResult.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)

    @staticmethod
    def SumValue(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/crudservice.CRUDService/SumValue',
            service__pb2.AggregationParam.SerializeToString,
            service__pb2.AggregationResult.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)