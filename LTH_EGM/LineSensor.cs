// Generated by ProtoGen, Version=2.4.1.555, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48.  DO NOT EDIT!
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.ProtocolBuffers;
using pbc = global::Google.ProtocolBuffers.Collections;
using pbd = global::Google.ProtocolBuffers.Descriptors;
using scg = global::System.Collections.Generic;
namespace lth.line_sensor {
  
  namespace Proto {
    
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public static partial class LineSensor {
    
      #region Extension registration
      public static void RegisterAllExtensions(pb::ExtensionRegistry registry) {
      }
      #endregion
      #region Static variables
      internal static pbd::MessageDescriptor internal__static_lth_line_sensor_Point__Descriptor;
      internal static pb::FieldAccess.FieldAccessorTable<global::lth.line_sensor.Point, global::lth.line_sensor.Point.Builder> internal__static_lth_line_sensor_Point__FieldAccessorTable;
      internal static pbd::MessageDescriptor internal__static_lth_line_sensor_LineSensor__Descriptor;
      internal static pb::FieldAccess.FieldAccessorTable<global::lth.line_sensor.LineSensor, global::lth.line_sensor.LineSensor.Builder> internal__static_lth_line_sensor_LineSensor__FieldAccessorTable;
      #endregion
      #region Descriptor
      public static pbd::FileDescriptor Descriptor {
        get { return descriptor; }
      }
      private static pbd::FileDescriptor descriptor;
      
      static LineSensor() {
        byte[] descriptorData = global::System.Convert.FromBase64String(
            string.Concat(
              "ChFsaW5lX3NlbnNvci5wcm90bxIPbHRoLmxpbmVfc2Vuc29yIigKBVBvaW50", 
              "EgkKAXgYASACKAESCQoBeRgCIAIoARIJCgF6GAMgAigBIrsBCgpMaW5lU2Vu", 
              "c29yEisKC3NlbnNlZFBvaW50GAEgAigLMhYubHRoLmxpbmVfc2Vuc29yLlBv", 
              "aW50EiUKBXN0YXJ0GAIgAigLMhYubHRoLmxpbmVfc2Vuc29yLlBvaW50EiMK", 
              "A2VuZBgDIAIoCzIWLmx0aC5saW5lX3NlbnNvci5Qb2ludBIOCgZyYWRpdXMY", 
            "BCACKAESEgoKc2Vuc2VkUGFydBgFIAIoCRIQCghzZW5zb3JJRBgGIAIoDQ=="));
        pbd::FileDescriptor.InternalDescriptorAssigner assigner = delegate(pbd::FileDescriptor root) {
          descriptor = root;
          internal__static_lth_line_sensor_Point__Descriptor = Descriptor.MessageTypes[0];
          internal__static_lth_line_sensor_Point__FieldAccessorTable = 
              new pb::FieldAccess.FieldAccessorTable<global::lth.line_sensor.Point, global::lth.line_sensor.Point.Builder>(internal__static_lth_line_sensor_Point__Descriptor,
                  new string[] { "X", "Y", "Z", });
          internal__static_lth_line_sensor_LineSensor__Descriptor = Descriptor.MessageTypes[1];
          internal__static_lth_line_sensor_LineSensor__FieldAccessorTable = 
              new pb::FieldAccess.FieldAccessorTable<global::lth.line_sensor.LineSensor, global::lth.line_sensor.LineSensor.Builder>(internal__static_lth_line_sensor_LineSensor__Descriptor,
                  new string[] { "SensedPoint", "Start", "End", "Radius", "SensedPart", "SensorID", });
          return null;
        };
        pbd::FileDescriptor.InternalBuildGeneratedFileFrom(descriptorData,
            new pbd::FileDescriptor[] {
            }, assigner);
      }
      #endregion
      
    }
  }
  #region Messages
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public sealed partial class Point : pb::GeneratedMessage<Point, Point.Builder> {
    private Point() { }
    private static readonly Point defaultInstance = new Point().MakeReadOnly();
    private static readonly string[] _pointFieldNames = new string[] { "x", "y", "z" };
    private static readonly uint[] _pointFieldTags = new uint[] { 9, 17, 25 };
    public static Point DefaultInstance {
      get { return defaultInstance; }
    }
    
    public override Point DefaultInstanceForType {
      get { return DefaultInstance; }
    }
    
    protected override Point ThisMessage {
      get { return this; }
    }
    
    public static pbd::MessageDescriptor Descriptor {
      get { return global::lth.line_sensor.Proto.LineSensor.internal__static_lth_line_sensor_Point__Descriptor; }
    }
    
    protected override pb::FieldAccess.FieldAccessorTable<Point, Point.Builder> InternalFieldAccessors {
      get { return global::lth.line_sensor.Proto.LineSensor.internal__static_lth_line_sensor_Point__FieldAccessorTable; }
    }
    
    public const int XFieldNumber = 1;
    private bool hasX;
    private double x_;
    public bool HasX {
      get { return hasX; }
    }
    public double X {
      get { return x_; }
    }
    
    public const int YFieldNumber = 2;
    private bool hasY;
    private double y_;
    public bool HasY {
      get { return hasY; }
    }
    public double Y {
      get { return y_; }
    }
    
    public const int ZFieldNumber = 3;
    private bool hasZ;
    private double z_;
    public bool HasZ {
      get { return hasZ; }
    }
    public double Z {
      get { return z_; }
    }
    
    public override bool IsInitialized {
      get {
        if (!hasX) return false;
        if (!hasY) return false;
        if (!hasZ) return false;
        return true;
      }
    }
    
    public override void WriteTo(pb::ICodedOutputStream output) {
      CalcSerializedSize();
      string[] field_names = _pointFieldNames;
      if (hasX) {
        output.WriteDouble(1, field_names[0], X);
      }
      if (hasY) {
        output.WriteDouble(2, field_names[1], Y);
      }
      if (hasZ) {
        output.WriteDouble(3, field_names[2], Z);
      }
      UnknownFields.WriteTo(output);
    }
    
    private int memoizedSerializedSize = -1;
    public override int SerializedSize {
      get {
        int size = memoizedSerializedSize;
        if (size != -1) return size;
        return CalcSerializedSize();
      }
    }
    
    private int CalcSerializedSize() {
      int size = memoizedSerializedSize;
      if (size != -1) return size;
      
      size = 0;
      if (hasX) {
        size += pb::CodedOutputStream.ComputeDoubleSize(1, X);
      }
      if (hasY) {
        size += pb::CodedOutputStream.ComputeDoubleSize(2, Y);
      }
      if (hasZ) {
        size += pb::CodedOutputStream.ComputeDoubleSize(3, Z);
      }
      size += UnknownFields.SerializedSize;
      memoizedSerializedSize = size;
      return size;
    }
    public static Point ParseFrom(pb::ByteString data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static Point ParseFrom(pb::ByteString data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static Point ParseFrom(byte[] data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static Point ParseFrom(byte[] data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static Point ParseFrom(global::System.IO.Stream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static Point ParseFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    public static Point ParseDelimitedFrom(global::System.IO.Stream input) {
      return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }
    public static Point ParseDelimitedFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }
    public static Point ParseFrom(pb::ICodedInputStream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static Point ParseFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    private Point MakeReadOnly() {
      return this;
    }
    
    public static Builder CreateBuilder() { return new Builder(); }
    public override Builder ToBuilder() { return CreateBuilder(this); }
    public override Builder CreateBuilderForType() { return new Builder(); }
    public static Builder CreateBuilder(Point prototype) {
      return new Builder(prototype);
    }
    
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public sealed partial class Builder : pb::GeneratedBuilder<Point, Builder> {
      protected override Builder ThisBuilder {
        get { return this; }
      }
      public Builder() {
        result = DefaultInstance;
        resultIsReadOnly = true;
      }
      internal Builder(Point cloneFrom) {
        result = cloneFrom;
        resultIsReadOnly = true;
      }
      
      private bool resultIsReadOnly;
      private Point result;
      
      private Point PrepareBuilder() {
        if (resultIsReadOnly) {
          Point original = result;
          result = new Point();
          resultIsReadOnly = false;
          MergeFrom(original);
        }
        return result;
      }
      
      public override bool IsInitialized {
        get { return result.IsInitialized; }
      }
      
      protected override Point MessageBeingBuilt {
        get { return PrepareBuilder(); }
      }
      
      public override Builder Clear() {
        result = DefaultInstance;
        resultIsReadOnly = true;
        return this;
      }
      
      public override Builder Clone() {
        if (resultIsReadOnly) {
          return new Builder(result);
        } else {
          return new Builder().MergeFrom(result);
        }
      }
      
      public override pbd::MessageDescriptor DescriptorForType {
        get { return global::lth.line_sensor.Point.Descriptor; }
      }
      
      public override Point DefaultInstanceForType {
        get { return global::lth.line_sensor.Point.DefaultInstance; }
      }
      
      public override Point BuildPartial() {
        if (resultIsReadOnly) {
          return result;
        }
        resultIsReadOnly = true;
        return result.MakeReadOnly();
      }
      
      public override Builder MergeFrom(pb::IMessage other) {
        if (other is Point) {
          return MergeFrom((Point) other);
        } else {
          base.MergeFrom(other);
          return this;
        }
      }
      
      public override Builder MergeFrom(Point other) {
        if (other == global::lth.line_sensor.Point.DefaultInstance) return this;
        PrepareBuilder();
        if (other.HasX) {
          X = other.X;
        }
        if (other.HasY) {
          Y = other.Y;
        }
        if (other.HasZ) {
          Z = other.Z;
        }
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }
      
      public override Builder MergeFrom(pb::ICodedInputStream input) {
        return MergeFrom(input, pb::ExtensionRegistry.Empty);
      }
      
      public override Builder MergeFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
        PrepareBuilder();
        pb::UnknownFieldSet.Builder unknownFields = null;
        uint tag;
        string field_name;
        while (input.ReadTag(out tag, out field_name)) {
          if(tag == 0 && field_name != null) {
            int field_ordinal = global::System.Array.BinarySearch(_pointFieldNames, field_name, global::System.StringComparer.Ordinal);
            if(field_ordinal >= 0)
              tag = _pointFieldTags[field_ordinal];
            else {
              if (unknownFields == null) {
                unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
              }
              ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
              continue;
            }
          }
          switch (tag) {
            case 0: {
              throw pb::InvalidProtocolBufferException.InvalidTag();
            }
            default: {
              if (pb::WireFormat.IsEndGroupTag(tag)) {
                if (unknownFields != null) {
                  this.UnknownFields = unknownFields.Build();
                }
                return this;
              }
              if (unknownFields == null) {
                unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
              }
              ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
              break;
            }
            case 9: {
              result.hasX = input.ReadDouble(ref result.x_);
              break;
            }
            case 17: {
              result.hasY = input.ReadDouble(ref result.y_);
              break;
            }
            case 25: {
              result.hasZ = input.ReadDouble(ref result.z_);
              break;
            }
          }
        }
        
        if (unknownFields != null) {
          this.UnknownFields = unknownFields.Build();
        }
        return this;
      }
      
      
      public bool HasX {
        get { return result.hasX; }
      }
      public double X {
        get { return result.X; }
        set { SetX(value); }
      }
      public Builder SetX(double value) {
        PrepareBuilder();
        result.hasX = true;
        result.x_ = value;
        return this;
      }
      public Builder ClearX() {
        PrepareBuilder();
        result.hasX = false;
        result.x_ = 0D;
        return this;
      }
      
      public bool HasY {
        get { return result.hasY; }
      }
      public double Y {
        get { return result.Y; }
        set { SetY(value); }
      }
      public Builder SetY(double value) {
        PrepareBuilder();
        result.hasY = true;
        result.y_ = value;
        return this;
      }
      public Builder ClearY() {
        PrepareBuilder();
        result.hasY = false;
        result.y_ = 0D;
        return this;
      }
      
      public bool HasZ {
        get { return result.hasZ; }
      }
      public double Z {
        get { return result.Z; }
        set { SetZ(value); }
      }
      public Builder SetZ(double value) {
        PrepareBuilder();
        result.hasZ = true;
        result.z_ = value;
        return this;
      }
      public Builder ClearZ() {
        PrepareBuilder();
        result.hasZ = false;
        result.z_ = 0D;
        return this;
      }
    }
    static Point() {
      object.ReferenceEquals(global::lth.line_sensor.Proto.LineSensor.Descriptor, null);
    }
  }
  
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public sealed partial class LineSensor : pb::GeneratedMessage<LineSensor, LineSensor.Builder> {
    private LineSensor() { }
    private static readonly LineSensor defaultInstance = new LineSensor().MakeReadOnly();
    private static readonly string[] _lineSensorFieldNames = new string[] { "end", "radius", "sensedPart", "sensedPoint", "sensorID", "start" };
    private static readonly uint[] _lineSensorFieldTags = new uint[] { 26, 33, 42, 10, 48, 18 };
    public static LineSensor DefaultInstance {
      get { return defaultInstance; }
    }
    
    public override LineSensor DefaultInstanceForType {
      get { return DefaultInstance; }
    }
    
    protected override LineSensor ThisMessage {
      get { return this; }
    }
    
    public static pbd::MessageDescriptor Descriptor {
      get { return global::lth.line_sensor.Proto.LineSensor.internal__static_lth_line_sensor_LineSensor__Descriptor; }
    }
    
    protected override pb::FieldAccess.FieldAccessorTable<LineSensor, LineSensor.Builder> InternalFieldAccessors {
      get { return global::lth.line_sensor.Proto.LineSensor.internal__static_lth_line_sensor_LineSensor__FieldAccessorTable; }
    }
    
    public const int SensedPointFieldNumber = 1;
    private bool hasSensedPoint;
    private global::lth.line_sensor.Point sensedPoint_;
    public bool HasSensedPoint {
      get { return hasSensedPoint; }
    }
    public global::lth.line_sensor.Point SensedPoint {
      get { return sensedPoint_ ?? global::lth.line_sensor.Point.DefaultInstance; }
    }
    
    public const int StartFieldNumber = 2;
    private bool hasStart;
    private global::lth.line_sensor.Point start_;
    public bool HasStart {
      get { return hasStart; }
    }
    public global::lth.line_sensor.Point Start {
      get { return start_ ?? global::lth.line_sensor.Point.DefaultInstance; }
    }
    
    public const int EndFieldNumber = 3;
    private bool hasEnd;
    private global::lth.line_sensor.Point end_;
    public bool HasEnd {
      get { return hasEnd; }
    }
    public global::lth.line_sensor.Point End {
      get { return end_ ?? global::lth.line_sensor.Point.DefaultInstance; }
    }
    
    public const int RadiusFieldNumber = 4;
    private bool hasRadius;
    private double radius_;
    public bool HasRadius {
      get { return hasRadius; }
    }
    public double Radius {
      get { return radius_; }
    }
    
    public const int SensedPartFieldNumber = 5;
    private bool hasSensedPart;
    private string sensedPart_ = "";
    public bool HasSensedPart {
      get { return hasSensedPart; }
    }
    public string SensedPart {
      get { return sensedPart_; }
    }
    
    public const int SensorIDFieldNumber = 6;
    private bool hasSensorID;
    private uint sensorID_;
    public bool HasSensorID {
      get { return hasSensorID; }
    }
    [global::System.CLSCompliant(false)]
    public uint SensorID {
      get { return sensorID_; }
    }
    
    public override bool IsInitialized {
      get {
        if (!hasSensedPoint) return false;
        if (!hasStart) return false;
        if (!hasEnd) return false;
        if (!hasRadius) return false;
        if (!hasSensedPart) return false;
        if (!hasSensorID) return false;
        if (!SensedPoint.IsInitialized) return false;
        if (!Start.IsInitialized) return false;
        if (!End.IsInitialized) return false;
        return true;
      }
    }
    
    public override void WriteTo(pb::ICodedOutputStream output) {
      CalcSerializedSize();
      string[] field_names = _lineSensorFieldNames;
      if (hasSensedPoint) {
        output.WriteMessage(1, field_names[3], SensedPoint);
      }
      if (hasStart) {
        output.WriteMessage(2, field_names[5], Start);
      }
      if (hasEnd) {
        output.WriteMessage(3, field_names[0], End);
      }
      if (hasRadius) {
        output.WriteDouble(4, field_names[1], Radius);
      }
      if (hasSensedPart) {
        output.WriteString(5, field_names[2], SensedPart);
      }
      if (hasSensorID) {
        output.WriteUInt32(6, field_names[4], SensorID);
      }
      UnknownFields.WriteTo(output);
    }
    
    private int memoizedSerializedSize = -1;
    public override int SerializedSize {
      get {
        int size = memoizedSerializedSize;
        if (size != -1) return size;
        return CalcSerializedSize();
      }
    }
    
    private int CalcSerializedSize() {
      int size = memoizedSerializedSize;
      if (size != -1) return size;
      
      size = 0;
      if (hasSensedPoint) {
        size += pb::CodedOutputStream.ComputeMessageSize(1, SensedPoint);
      }
      if (hasStart) {
        size += pb::CodedOutputStream.ComputeMessageSize(2, Start);
      }
      if (hasEnd) {
        size += pb::CodedOutputStream.ComputeMessageSize(3, End);
      }
      if (hasRadius) {
        size += pb::CodedOutputStream.ComputeDoubleSize(4, Radius);
      }
      if (hasSensedPart) {
        size += pb::CodedOutputStream.ComputeStringSize(5, SensedPart);
      }
      if (hasSensorID) {
        size += pb::CodedOutputStream.ComputeUInt32Size(6, SensorID);
      }
      size += UnknownFields.SerializedSize;
      memoizedSerializedSize = size;
      return size;
    }
    public static LineSensor ParseFrom(pb::ByteString data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static LineSensor ParseFrom(pb::ByteString data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static LineSensor ParseFrom(byte[] data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static LineSensor ParseFrom(byte[] data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static LineSensor ParseFrom(global::System.IO.Stream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static LineSensor ParseFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    public static LineSensor ParseDelimitedFrom(global::System.IO.Stream input) {
      return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }
    public static LineSensor ParseDelimitedFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }
    public static LineSensor ParseFrom(pb::ICodedInputStream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static LineSensor ParseFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    private LineSensor MakeReadOnly() {
      return this;
    }
    
    public static Builder CreateBuilder() { return new Builder(); }
    public override Builder ToBuilder() { return CreateBuilder(this); }
    public override Builder CreateBuilderForType() { return new Builder(); }
    public static Builder CreateBuilder(LineSensor prototype) {
      return new Builder(prototype);
    }
    
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public sealed partial class Builder : pb::GeneratedBuilder<LineSensor, Builder> {
      protected override Builder ThisBuilder {
        get { return this; }
      }
      public Builder() {
        result = DefaultInstance;
        resultIsReadOnly = true;
      }
      internal Builder(LineSensor cloneFrom) {
        result = cloneFrom;
        resultIsReadOnly = true;
      }
      
      private bool resultIsReadOnly;
      private LineSensor result;
      
      private LineSensor PrepareBuilder() {
        if (resultIsReadOnly) {
          LineSensor original = result;
          result = new LineSensor();
          resultIsReadOnly = false;
          MergeFrom(original);
        }
        return result;
      }
      
      public override bool IsInitialized {
        get { return result.IsInitialized; }
      }
      
      protected override LineSensor MessageBeingBuilt {
        get { return PrepareBuilder(); }
      }
      
      public override Builder Clear() {
        result = DefaultInstance;
        resultIsReadOnly = true;
        return this;
      }
      
      public override Builder Clone() {
        if (resultIsReadOnly) {
          return new Builder(result);
        } else {
          return new Builder().MergeFrom(result);
        }
      }
      
      public override pbd::MessageDescriptor DescriptorForType {
        get { return global::lth.line_sensor.LineSensor.Descriptor; }
      }
      
      public override LineSensor DefaultInstanceForType {
        get { return global::lth.line_sensor.LineSensor.DefaultInstance; }
      }
      
      public override LineSensor BuildPartial() {
        if (resultIsReadOnly) {
          return result;
        }
        resultIsReadOnly = true;
        return result.MakeReadOnly();
      }
      
      public override Builder MergeFrom(pb::IMessage other) {
        if (other is LineSensor) {
          return MergeFrom((LineSensor) other);
        } else {
          base.MergeFrom(other);
          return this;
        }
      }
      
      public override Builder MergeFrom(LineSensor other) {
        if (other == global::lth.line_sensor.LineSensor.DefaultInstance) return this;
        PrepareBuilder();
        if (other.HasSensedPoint) {
          MergeSensedPoint(other.SensedPoint);
        }
        if (other.HasStart) {
          MergeStart(other.Start);
        }
        if (other.HasEnd) {
          MergeEnd(other.End);
        }
        if (other.HasRadius) {
          Radius = other.Radius;
        }
        if (other.HasSensedPart) {
          SensedPart = other.SensedPart;
        }
        if (other.HasSensorID) {
          SensorID = other.SensorID;
        }
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }
      
      public override Builder MergeFrom(pb::ICodedInputStream input) {
        return MergeFrom(input, pb::ExtensionRegistry.Empty);
      }
      
      public override Builder MergeFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
        PrepareBuilder();
        pb::UnknownFieldSet.Builder unknownFields = null;
        uint tag;
        string field_name;
        while (input.ReadTag(out tag, out field_name)) {
          if(tag == 0 && field_name != null) {
            int field_ordinal = global::System.Array.BinarySearch(_lineSensorFieldNames, field_name, global::System.StringComparer.Ordinal);
            if(field_ordinal >= 0)
              tag = _lineSensorFieldTags[field_ordinal];
            else {
              if (unknownFields == null) {
                unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
              }
              ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
              continue;
            }
          }
          switch (tag) {
            case 0: {
              throw pb::InvalidProtocolBufferException.InvalidTag();
            }
            default: {
              if (pb::WireFormat.IsEndGroupTag(tag)) {
                if (unknownFields != null) {
                  this.UnknownFields = unknownFields.Build();
                }
                return this;
              }
              if (unknownFields == null) {
                unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
              }
              ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
              break;
            }
            case 10: {
              global::lth.line_sensor.Point.Builder subBuilder = global::lth.line_sensor.Point.CreateBuilder();
              if (result.hasSensedPoint) {
                subBuilder.MergeFrom(SensedPoint);
              }
              input.ReadMessage(subBuilder, extensionRegistry);
              SensedPoint = subBuilder.BuildPartial();
              break;
            }
            case 18: {
              global::lth.line_sensor.Point.Builder subBuilder = global::lth.line_sensor.Point.CreateBuilder();
              if (result.hasStart) {
                subBuilder.MergeFrom(Start);
              }
              input.ReadMessage(subBuilder, extensionRegistry);
              Start = subBuilder.BuildPartial();
              break;
            }
            case 26: {
              global::lth.line_sensor.Point.Builder subBuilder = global::lth.line_sensor.Point.CreateBuilder();
              if (result.hasEnd) {
                subBuilder.MergeFrom(End);
              }
              input.ReadMessage(subBuilder, extensionRegistry);
              End = subBuilder.BuildPartial();
              break;
            }
            case 33: {
              result.hasRadius = input.ReadDouble(ref result.radius_);
              break;
            }
            case 42: {
              result.hasSensedPart = input.ReadString(ref result.sensedPart_);
              break;
            }
            case 48: {
              result.hasSensorID = input.ReadUInt32(ref result.sensorID_);
              break;
            }
          }
        }
        
        if (unknownFields != null) {
          this.UnknownFields = unknownFields.Build();
        }
        return this;
      }
      
      
      public bool HasSensedPoint {
       get { return result.hasSensedPoint; }
      }
      public global::lth.line_sensor.Point SensedPoint {
        get { return result.SensedPoint; }
        set { SetSensedPoint(value); }
      }
      public Builder SetSensedPoint(global::lth.line_sensor.Point value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasSensedPoint = true;
        result.sensedPoint_ = value;
        return this;
      }
      public Builder SetSensedPoint(global::lth.line_sensor.Point.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.hasSensedPoint = true;
        result.sensedPoint_ = builderForValue.Build();
        return this;
      }
      public Builder MergeSensedPoint(global::lth.line_sensor.Point value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        if (result.hasSensedPoint &&
            result.sensedPoint_ != global::lth.line_sensor.Point.DefaultInstance) {
            result.sensedPoint_ = global::lth.line_sensor.Point.CreateBuilder(result.sensedPoint_).MergeFrom(value).BuildPartial();
        } else {
          result.sensedPoint_ = value;
        }
        result.hasSensedPoint = true;
        return this;
      }
      public Builder ClearSensedPoint() {
        PrepareBuilder();
        result.hasSensedPoint = false;
        result.sensedPoint_ = null;
        return this;
      }
      
      public bool HasStart {
       get { return result.hasStart; }
      }
      public global::lth.line_sensor.Point Start {
        get { return result.Start; }
        set { SetStart(value); }
      }
      public Builder SetStart(global::lth.line_sensor.Point value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasStart = true;
        result.start_ = value;
        return this;
      }
      public Builder SetStart(global::lth.line_sensor.Point.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.hasStart = true;
        result.start_ = builderForValue.Build();
        return this;
      }
      public Builder MergeStart(global::lth.line_sensor.Point value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        if (result.hasStart &&
            result.start_ != global::lth.line_sensor.Point.DefaultInstance) {
            result.start_ = global::lth.line_sensor.Point.CreateBuilder(result.start_).MergeFrom(value).BuildPartial();
        } else {
          result.start_ = value;
        }
        result.hasStart = true;
        return this;
      }
      public Builder ClearStart() {
        PrepareBuilder();
        result.hasStart = false;
        result.start_ = null;
        return this;
      }
      
      public bool HasEnd {
       get { return result.hasEnd; }
      }
      public global::lth.line_sensor.Point End {
        get { return result.End; }
        set { SetEnd(value); }
      }
      public Builder SetEnd(global::lth.line_sensor.Point value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasEnd = true;
        result.end_ = value;
        return this;
      }
      public Builder SetEnd(global::lth.line_sensor.Point.Builder builderForValue) {
        pb::ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
        PrepareBuilder();
        result.hasEnd = true;
        result.end_ = builderForValue.Build();
        return this;
      }
      public Builder MergeEnd(global::lth.line_sensor.Point value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        if (result.hasEnd &&
            result.end_ != global::lth.line_sensor.Point.DefaultInstance) {
            result.end_ = global::lth.line_sensor.Point.CreateBuilder(result.end_).MergeFrom(value).BuildPartial();
        } else {
          result.end_ = value;
        }
        result.hasEnd = true;
        return this;
      }
      public Builder ClearEnd() {
        PrepareBuilder();
        result.hasEnd = false;
        result.end_ = null;
        return this;
      }
      
      public bool HasRadius {
        get { return result.hasRadius; }
      }
      public double Radius {
        get { return result.Radius; }
        set { SetRadius(value); }
      }
      public Builder SetRadius(double value) {
        PrepareBuilder();
        result.hasRadius = true;
        result.radius_ = value;
        return this;
      }
      public Builder ClearRadius() {
        PrepareBuilder();
        result.hasRadius = false;
        result.radius_ = 0D;
        return this;
      }
      
      public bool HasSensedPart {
        get { return result.hasSensedPart; }
      }
      public string SensedPart {
        get { return result.SensedPart; }
        set { SetSensedPart(value); }
      }
      public Builder SetSensedPart(string value) {
        pb::ThrowHelper.ThrowIfNull(value, "value");
        PrepareBuilder();
        result.hasSensedPart = true;
        result.sensedPart_ = value;
        return this;
      }
      public Builder ClearSensedPart() {
        PrepareBuilder();
        result.hasSensedPart = false;
        result.sensedPart_ = "";
        return this;
      }
      
      public bool HasSensorID {
        get { return result.hasSensorID; }
      }
      [global::System.CLSCompliant(false)]
      public uint SensorID {
        get { return result.SensorID; }
        set { SetSensorID(value); }
      }
      [global::System.CLSCompliant(false)]
      public Builder SetSensorID(uint value) {
        PrepareBuilder();
        result.hasSensorID = true;
        result.sensorID_ = value;
        return this;
      }
      public Builder ClearSensorID() {
        PrepareBuilder();
        result.hasSensorID = false;
        result.sensorID_ = 0;
        return this;
      }
    }
    static LineSensor() {
      object.ReferenceEquals(global::lth.line_sensor.Proto.LineSensor.Descriptor, null);
    }
  }
  
  #endregion
  
}

#endregion Designer generated code
