// Licensed to Elasticsearch B.V. under one or more contributor
// license agreements. See the NOTICE file distributed with
// this work for additional information regarding copyright
// ownership. Elasticsearch B.V. licenses this file to you under
// the Apache License, Version 2.0 (the "License"); you may
// not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.

// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;

namespace ElasticCommonSchema
{
    ///<summary>
    /// Elastic Common Schema type.
    /// <para/>
    /// The Elastic Common Schema (ECS) defines a common set of fields for ingesting data into Elasticsearch.
    /// A common schema helps you correlate data from sources like logs and metrics or IT operations analytics
    /// and security analytics.
    /// <para/>
    /// https://github.com/elastic/ecs
    ///</summary>
    public class ECS
    {
        ///<summary>
        /// The agent fields contain the data about the software entity, if any, that collects, detects, or observes events on a host, or takes measurements on a host. Examples include Beats. Agents may also run on observers. ECS agent.* fields shall be populated with details of the agent running on the host or observer where the event happened or the measurement was taken.
        ///</summary>
        [DataMember(Name = "agent")]
        public Agent Agent { get; set; }

        ///<summary>
        /// A client is defined as the initiator of a network connection for events regarding sessions, connections, or bidirectional flow records. For TCP events, the client is the initiator of the TCP connection that sends the SYN packet(s). For other protocols, the client is generally the initiator or requestor in the network transaction. Some systems use the term &quot;originator&quot; to refer the client in TCP connections. The client fields describe details about the system acting as the client in the network event. Client fields are usually populated in conjunction with server fields. Client fields are generally not populated for packet-level events. Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
        ///</summary>
        [DataMember(Name = "client")]
        public Client Client { get; set; }

        ///<summary>
        /// Fields related to the cloud or infrastructure the events are coming from.
        ///</summary>
        [DataMember(Name = "cloud")]
        public Cloud Cloud { get; set; }

        ///<summary>
        /// Container fields are used for meta information about the specific container that is the source of information. These fields help correlate data based containers from any runtime.
        ///</summary>
        [DataMember(Name = "container")]
        public Container Container { get; set; }

        ///<summary>
        /// Destination fields describe details about the destination of a packet/event. Destination fields are usually populated in conjunction with source fields.
        ///</summary>
        [DataMember(Name = "destination")]
        public Destination Destination { get; set; }

        ///<summary>
        /// Meta-information specific to ECS.
        ///</summary>
        [DataMember(Name = "ecs")]
        public Ecs Ecs { get; set; }

        ///<summary>
        /// These fields can represent errors of any kind. Use them for errors that happen while fetching events or in cases where the event itself contains an error.
        ///</summary>
        [DataMember(Name = "error")]
        public Error Error { get; set; }

        ///<summary>
        /// The event fields are used for context information about the log or metric event itself. A log is defined as an event containing details of something that happened. Log events must include the time at which the thing happened. Examples of log events include a process starting on a host, a network packet being sent from a source to a destination, or a network connection between a client and a server being initiated or closed. A metric is defined as an event containing one or more numerical or categorical measurements and the time at which the measurement was taken. Examples of metric events include memory pressure measured on a host, or vulnerabilities measured on a scanned host.
        ///</summary>
        [DataMember(Name = "event")]
        public Event Event { get; set; }

        ///<summary>
        /// A file is defined as a set of information that has been created on, or has existed on a filesystem. File objects can be associated with host events, network events, and/or file events (e.g., those produced by File Integrity Monitoring [FIM] products or services). File fields provide details about the affected file associated with the event or metric.
        ///</summary>
        [DataMember(Name = "file")]
        public File File { get; set; }

        ///<summary>
        /// Geo fields can carry data about a specific location related to an event. This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
        ///</summary>
        [DataMember(Name = "geo")]
        public Geo Geo { get; set; }

        ///<summary>
        /// The group fields are meant to represent groups that are relevant to the event.
        ///</summary>
        [DataMember(Name = "group")]
        public Group Group { get; set; }

        ///<summary>
        /// A host is defined as a general computing instance. ECS host.* fields should be populated with details about the host on which the event happened, or from which the measurement was taken. Host types include hardware, virtual machines, Docker containers, and Kubernetes nodes.
        ///</summary>
        [DataMember(Name = "host")]
        public Host Host { get; set; }

        ///<summary>
        /// Fields related to HTTP activity. Use the `url` field set to store the url of the request.
        ///</summary>
        [DataMember(Name = "http")]
        public Http Http { get; set; }

        ///<summary>
        /// Fields which are specific to log events.
        ///</summary>
        [DataMember(Name = "log")]
        public Log Log { get; set; }

        ///<summary>
        /// The network is defined as the communication path over which a host or network event happens. The network.* fields should be populated with details about the network activity associated with an event.
        ///</summary>
        [DataMember(Name = "network")]
        public Network Network { get; set; }

        ///<summary>
        /// An observer is defined as a special network, security, or application device used to detect, observe, or create network, security, or application-related events and metrics. This could be a custom hardware appliance or a server that has been configured to run special network, security, or application software. Examples include firewalls, intrusion detection/prevention systems, network monitoring sensors, web application firewalls, data loss prevention systems, and APM servers. The observer.* fields shall be populated with details of the system, if any, that detects, observes and/or creates a network, security, or application event or metric. Message queues and ETL components used in processing events or metrics are not considered observers in ECS.
        ///</summary>
        [DataMember(Name = "observer")]
        public Observer Observer { get; set; }

        ///<summary>
        /// The organization fields enrich data with information about the company or entity the data is associated with. These fields help you arrange or filter data stored in an index by one or multiple organizations.
        ///</summary>
        [DataMember(Name = "organization")]
        public Organization Organization { get; set; }

        ///<summary>
        /// The OS fields contain information about the operating system.
        ///</summary>
        [DataMember(Name = "os")]
        public Os Os { get; set; }

        ///<summary>
        /// These fields contain information about a process. These fields can help you correlate metrics information with a process id/name from a log message.  The `process.pid` often stays in the metric itself and is copied to the global field for correlation.
        ///</summary>
        [DataMember(Name = "process")]
        public Process Process { get; set; }

        ///<summary>
        /// This field set is meant to facilitate pivoting around a piece of data. Some pieces of information can be seen in many places in an ECS event. To facilitate searching for them, store an array of all seen values to their corresponding field in `related.`. A concrete example is IP addresses, which can be under host, observer, source, destination, client, server, and network.forwarded_ip. If you append all IPs to `related.ip`, you can then search for a given IP trivially, no matter where it appeared, by querying `related.ip:a.b.c.d`.
        ///</summary>
        [DataMember(Name = "related")]
        public Related Related { get; set; }

        ///<summary>
        /// A Server is defined as the responder in a network connection for events regarding sessions, connections, or bidirectional flow records. For TCP events, the server is the receiver of the initial SYN packet(s) of the TCP connection. For other protocols, the server is generally the responder in the network transaction. Some systems actually use the term &quot;responder&quot; to refer the server in TCP connections. The server fields describe details about the system acting as the server in the network event. Server fields are usually populated in conjunction with client fields. Server fields are generally not populated for packet-level events. Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
        ///</summary>
        [DataMember(Name = "server")]
        public Server Server { get; set; }

        ///<summary>
        /// The service fields describe the service for or from which the data was collected. These fields help you find and correlate logs for a specific service and version.
        ///</summary>
        [DataMember(Name = "service")]
        public Service Service { get; set; }

        ///<summary>
        /// Source fields describe details about the source of a packet/event. Source fields are usually populated in conjunction with destination fields.
        ///</summary>
        [DataMember(Name = "source")]
        public Source Source { get; set; }

        ///<summary>
        /// URL fields provide support for complete or partial URLs, and supports the breaking down into scheme, domain, path, and so on.
        ///</summary>
        [DataMember(Name = "url")]
        public Url Url { get; set; }

        ///<summary>
        /// The user fields describe information about the user that is relevant to the event. Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
        ///</summary>
        [DataMember(Name = "user")]
        public User User { get; set; }

        ///<summary>
        /// The user_agent fields normally come from a browser request. They often show up in web service logs coming from the parsed user agent string.
        ///</summary>
        [DataMember(Name = "user_agent")]
        public UserAgent UserAgent { get; set; }

        ///<summary>
        /// Date/time when the event originated. This is the date/time extracted from the event, typically representing when the event was generated by the source. If the event source has no original timestamp, this value is typically populated by the first time the event was received by the pipeline. Required field for all events.
        ///</summary>
        ///<example>2016-05-23T08:05:34.853Z</example>
        [DataMember(Name = "@timestamp")]
        public DateTimeOffset?  { get; set; }

        ///<summary>
        /// List of keywords used to tag each event.
        ///</summary>
        ///<example>[\"production\", \"env2\"]</example>
        [DataMember(Name = "tags")]
        public string  { get; set; }

        ///<summary>
        /// Custom key/value pairs. Can be used to add meta information to events. Should not contain nested objects. All values are stored as keyword. Example: `docker` and `k8s` labels.
        ///</summary>
        ///<example>{"application":"foo-bar","env":"production"}</example>
        [DataMember(Name = "labels")]
        public object  { get; set; }

        ///<summary>
        /// For log events the message field contains the log message, optimized for viewing in a log viewer. For structured logs without an original message field, other fields can be concatenated to form a human-readable summary of the event. If multiple messages exist, they can be combined into one message.
        ///</summary>
        ///<example>Hello World</example>
        [DataMember(Name = "message")]
        public string  { get; set; }

    }

    ///<summary>
    /// Agent
    /// <para />
    /// The agent fields contain the data about the software entity, if any, that collects, detects, or observes events on a host, or takes measurements on a host. Examples include Beats. Agents may also run on observers. ECS agent.* fields shall be populated with details of the agent running on the host or observer where the event happened or the measurement was taken.
    ///</summary>
    ///<remarks>
    /// Examples: In the case of Beats for logs, the agent.name is filebeat. For APM, it is the agent running in the app/service. The agent information does not change if data is sent through queuing systems like Kafka, Redis, or processing systems such as Logstash or APM Server.
    ///</remarks>
    public class Agent 
    {
        ///<summary>
        /// Version of the agent.
        ///</summary>
        ///<example>6.0.0-rc2</example>
        [DataMember(Name = "agent.version")]
        public string Version { get; set; }

        ///<summary>
        /// Custom name of the agent. This is a name that can be given to an agent. This can be helpful if for example two Filebeat instances are running on the same host but a human readable separation is needed on which Filebeat instance data is coming from. If no name is given, the name is often left empty.
        ///</summary>
        ///<example>foo</example>
        [DataMember(Name = "agent.name")]
        public string Name { get; set; }

        ///<summary>
        /// Type of the agent. The agent type stays always the same and should be given by the agent used. In case of Filebeat the agent would always be Filebeat also if two Filebeat instances are run on the same machine.
        ///</summary>
        ///<example>filebeat</example>
        [DataMember(Name = "agent.type")]
        public string Type { get; set; }

        ///<summary>
        /// Unique identifier of this agent (if one exists). Example: For Beats this would be beat.id.
        ///</summary>
        ///<example>8a4f500d</example>
        [DataMember(Name = "agent.id")]
        public string Id { get; set; }

        ///<summary>
        /// Ephemeral identifier of this agent (if one exists). This id normally changes across restarts, but `agent.id` does not.
        ///</summary>
        ///<example>8a4f500f</example>
        [DataMember(Name = "agent.ephemeral_id")]
        public string EphemeralId { get; set; }

    }
    ///<summary>
    /// Client
    /// <para />
    /// A client is defined as the initiator of a network connection for events regarding sessions, connections, or bidirectional flow records. For TCP events, the client is the initiator of the TCP connection that sends the SYN packet(s). For other protocols, the client is generally the initiator or requestor in the network transaction. Some systems use the term &quot;originator&quot; to refer the client in TCP connections. The client fields describe details about the system acting as the client in the network event. Client fields are usually populated in conjunction with server fields. Client fields are generally not populated for packet-level events. Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
    ///</summary>
    public class Client 
    {
        ///<summary>
        /// Some event client addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field. Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
        ///</summary>
        [DataMember(Name = "client.address")]
        public string Address { get; set; }

        ///<summary>
        /// Longitude and latitude.
        ///</summary>
        ///<example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "client.geo.location")]
        public GeoPoint GeoLocation { get; set; }

        ///<summary>
        /// Unique identifier for the group on the system/platform.
        ///</summary>
        [DataMember(Name = "client.user.group.id")]
        public string UserGroupId { get; set; }

        ///<summary>
        /// One or multiple unique identifiers of the user.
        ///</summary>
        [DataMember(Name = "client.user.id")]
        public string UserId { get; set; }

        ///<summary>
        /// Name of the continent.
        ///</summary>
        ///<example>North America</example>
        [DataMember(Name = "client.geo.continent_name")]
        public string GeoContinentName { get; set; }

        ///<summary>
        /// IP address of the client. Can be one or multiple IPv4 or IPv6 addresses.
        ///</summary>
        [DataMember(Name = "client.ip")]
        public IPAddress Ip { get; set; }

        ///<summary>
        /// Name of the group.
        ///</summary>
        [DataMember(Name = "client.user.group.name")]
        public string UserGroupName { get; set; }

        ///<summary>
        /// Short name or login of the user.
        ///</summary>
        ///<example>albert</example>
        [DataMember(Name = "client.user.name")]
        public string UserName { get; set; }

        ///<summary>
        /// Country name.
        ///</summary>
        ///<example>Canada</example>
        [DataMember(Name = "client.geo.country_name")]
        public string GeoCountryName { get; set; }

        ///<summary>
        /// Port of the client.
        ///</summary>
        [DataMember(Name = "client.port")]
        public long? Port { get; set; }

        ///<summary>
        /// User&#x27;s full name, if available.
        ///</summary>
        ///<example>Albert Einstein</example>
        [DataMember(Name = "client.user.full_name")]
        public string UserFullName { get; set; }

        ///<summary>
        /// Region name.
        ///</summary>
        ///<example>Quebec</example>
        [DataMember(Name = "client.geo.region_name")]
        public string GeoRegionName { get; set; }

        ///<summary>
        /// MAC address of the client.
        ///</summary>
        [DataMember(Name = "client.mac")]
        public string Mac { get; set; }

        ///<summary>
        /// User email address.
        ///</summary>
        [DataMember(Name = "client.user.email")]
        public string UserEmail { get; set; }

        ///<summary>
        /// Client domain.
        ///</summary>
        [DataMember(Name = "client.domain")]
        public string Domain { get; set; }

        ///<summary>
        /// City name.
        ///</summary>
        ///<example>Montreal</example>
        [DataMember(Name = "client.geo.city_name")]
        public string GeoCityName { get; set; }

        ///<summary>
        /// Unique user hash to correlate information for a user in anonymized form. Useful if `user.id` or `user.name` contain confidential information and cannot be used.
        ///</summary>
        [DataMember(Name = "client.user.hash")]
        public string UserHash { get; set; }

        ///<summary>
        /// Bytes sent from the client to the server.
        ///</summary>
        ///<example>184</example>
        [DataMember(Name = "client.bytes")]
        public long? Bytes { get; set; }

        ///<summary>
        /// Country ISO code.
        ///</summary>
        ///<example>CA</example>
        [DataMember(Name = "client.geo.country_iso_code")]
        public string GeoCountryIsoCode { get; set; }

        ///<summary>
        /// Region ISO code.
        ///</summary>
        ///<example>CA-QC</example>
        [DataMember(Name = "client.geo.region_iso_code")]
        public string GeoRegionIsoCode { get; set; }

        ///<summary>
        /// Packets sent from the client to the server.
        ///</summary>
        ///<example>12</example>
        [DataMember(Name = "client.packets")]
        public long? Packets { get; set; }

        ///<summary>
        /// User-defined description of a location, at the level of granularity they care about. Could be the name of their data centers, the floor number, if this describes a local physical entity, city names. Not typically used in automated geolocation.
        ///</summary>
        ///<example>boston-dc</example>
        [DataMember(Name = "client.geo.name")]
        public string GeoName { get; set; }

    }
    ///<summary>
    /// Cloud
    /// <para />
    /// Fields related to the cloud or infrastructure the events are coming from.
    ///</summary>
    ///<remarks>
    /// Examples: If Metricbeat is running on an EC2 host and fetches data from its host, the cloud info contains the data about this machine. If Metricbeat runs on a remote machine outside the cloud and fetches data from a service running in the cloud, the field contains cloud data from the machine the service is running on.
    ///</remarks>
    public class Cloud 
    {
        ///<summary>
        /// Name of the cloud provider. Example values are aws, azure, gcp, or digitalocean.
        ///</summary>
        ///<example>aws</example>
        [DataMember(Name = "cloud.provider")]
        public string Provider { get; set; }

        ///<summary>
        /// Availability zone in which this host is running.
        ///</summary>
        ///<example>us-east-1c</example>
        [DataMember(Name = "cloud.availability_zone")]
        public string AvailabilityZone { get; set; }

        ///<summary>
        /// Region in which this host is running.
        ///</summary>
        ///<example>us-east-1</example>
        [DataMember(Name = "cloud.region")]
        public string Region { get; set; }

        ///<summary>
        /// Instance ID of the host machine.
        ///</summary>
        ///<example>i-1234567890abcdef0</example>
        [DataMember(Name = "cloud.instance.id")]
        public string InstanceId { get; set; }

        ///<summary>
        /// Instance name of the host machine.
        ///</summary>
        [DataMember(Name = "cloud.instance.name")]
        public string InstanceName { get; set; }

        ///<summary>
        /// Machine type of the host machine.
        ///</summary>
        ///<example>t2.medium</example>
        [DataMember(Name = "cloud.machine.type")]
        public string MachineType { get; set; }

        ///<summary>
        /// The cloud account or organization id used to identify different entities in a multi-tenant environment. Examples: AWS account id, Google Cloud ORG Id, or other unique identifier.
        ///</summary>
        ///<example>666777888999</example>
        [DataMember(Name = "cloud.account.id")]
        public string AccountId { get; set; }

    }
    ///<summary>
    /// Container
    /// <para />
    /// Container fields are used for meta information about the specific container that is the source of information. These fields help correlate data based containers from any runtime.
    ///</summary>
    public class Container 
    {
        ///<summary>
        /// Runtime managing this container.
        ///</summary>
        ///<example>docker</example>
        [DataMember(Name = "container.runtime")]
        public string Runtime { get; set; }

        ///<summary>
        /// Unique container id.
        ///</summary>
        [DataMember(Name = "container.id")]
        public string Id { get; set; }

        ///<summary>
        /// Name of the image the container was built on.
        ///</summary>
        [DataMember(Name = "container.image.name")]
        public string ImageName { get; set; }

        ///<summary>
        /// Container image tag.
        ///</summary>
        [DataMember(Name = "container.image.tag")]
        public string ImageTag { get; set; }

        ///<summary>
        /// Container name.
        ///</summary>
        [DataMember(Name = "container.name")]
        public string Name { get; set; }

        ///<summary>
        /// Image labels.
        ///</summary>
        [DataMember(Name = "container.labels")]
        public object Labels { get; set; }

    }
    ///<summary>
    /// Destination
    /// <para />
    /// Destination fields describe details about the destination of a packet/event. Destination fields are usually populated in conjunction with source fields.
    ///</summary>
    public class Destination 
    {
        ///<summary>
        /// Some event destination addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field. Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
        ///</summary>
        [DataMember(Name = "destination.address")]
        public string Address { get; set; }

        ///<summary>
        /// Longitude and latitude.
        ///</summary>
        ///<example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "destination.geo.location")]
        public GeoPoint GeoLocation { get; set; }

        ///<summary>
        /// Unique identifier for the group on the system/platform.
        ///</summary>
        [DataMember(Name = "destination.user.group.id")]
        public string UserGroupId { get; set; }

        ///<summary>
        /// One or multiple unique identifiers of the user.
        ///</summary>
        [DataMember(Name = "destination.user.id")]
        public string UserId { get; set; }

        ///<summary>
        /// Name of the continent.
        ///</summary>
        ///<example>North America</example>
        [DataMember(Name = "destination.geo.continent_name")]
        public string GeoContinentName { get; set; }

        ///<summary>
        /// IP address of the destination. Can be one or multiple IPv4 or IPv6 addresses.
        ///</summary>
        [DataMember(Name = "destination.ip")]
        public IPAddress Ip { get; set; }

        ///<summary>
        /// Name of the group.
        ///</summary>
        [DataMember(Name = "destination.user.group.name")]
        public string UserGroupName { get; set; }

        ///<summary>
        /// Short name or login of the user.
        ///</summary>
        ///<example>albert</example>
        [DataMember(Name = "destination.user.name")]
        public string UserName { get; set; }

        ///<summary>
        /// Country name.
        ///</summary>
        ///<example>Canada</example>
        [DataMember(Name = "destination.geo.country_name")]
        public string GeoCountryName { get; set; }

        ///<summary>
        /// Port of the destination.
        ///</summary>
        [DataMember(Name = "destination.port")]
        public long? Port { get; set; }

        ///<summary>
        /// User&#x27;s full name, if available.
        ///</summary>
        ///<example>Albert Einstein</example>
        [DataMember(Name = "destination.user.full_name")]
        public string UserFullName { get; set; }

        ///<summary>
        /// Region name.
        ///</summary>
        ///<example>Quebec</example>
        [DataMember(Name = "destination.geo.region_name")]
        public string GeoRegionName { get; set; }

        ///<summary>
        /// MAC address of the destination.
        ///</summary>
        [DataMember(Name = "destination.mac")]
        public string Mac { get; set; }

        ///<summary>
        /// User email address.
        ///</summary>
        [DataMember(Name = "destination.user.email")]
        public string UserEmail { get; set; }

        ///<summary>
        /// Destination domain.
        ///</summary>
        [DataMember(Name = "destination.domain")]
        public string Domain { get; set; }

        ///<summary>
        /// City name.
        ///</summary>
        ///<example>Montreal</example>
        [DataMember(Name = "destination.geo.city_name")]
        public string GeoCityName { get; set; }

        ///<summary>
        /// Unique user hash to correlate information for a user in anonymized form. Useful if `user.id` or `user.name` contain confidential information and cannot be used.
        ///</summary>
        [DataMember(Name = "destination.user.hash")]
        public string UserHash { get; set; }

        ///<summary>
        /// Bytes sent from the destination to the source.
        ///</summary>
        ///<example>184</example>
        [DataMember(Name = "destination.bytes")]
        public long? Bytes { get; set; }

        ///<summary>
        /// Country ISO code.
        ///</summary>
        ///<example>CA</example>
        [DataMember(Name = "destination.geo.country_iso_code")]
        public string GeoCountryIsoCode { get; set; }

        ///<summary>
        /// Region ISO code.
        ///</summary>
        ///<example>CA-QC</example>
        [DataMember(Name = "destination.geo.region_iso_code")]
        public string GeoRegionIsoCode { get; set; }

        ///<summary>
        /// Packets sent from the destination to the source.
        ///</summary>
        ///<example>12</example>
        [DataMember(Name = "destination.packets")]
        public long? Packets { get; set; }

        ///<summary>
        /// User-defined description of a location, at the level of granularity they care about. Could be the name of their data centers, the floor number, if this describes a local physical entity, city names. Not typically used in automated geolocation.
        ///</summary>
        ///<example>boston-dc</example>
        [DataMember(Name = "destination.geo.name")]
        public string GeoName { get; set; }

    }
    ///<summary>
    /// ECS
    /// <para />
    /// Meta-information specific to ECS.
    ///</summary>
    public class Ecs 
    {
        ///<summary>
        /// ECS version this event conforms to. `ecs.version` is a required field and must exist in all events. When querying across multiple indices -- which may conform to slightly different ECS versions -- this field lets integrations adjust to the schema version of the events.
        ///</summary>
        ///<example>1.0.0</example>
        [DataMember(Name = "ecs.version")]
        public string Version { get; set; }

    }
    ///<summary>
    /// Error
    /// <para />
    /// These fields can represent errors of any kind. Use them for errors that happen while fetching events or in cases where the event itself contains an error.
    ///</summary>
    public class Error 
    {
        ///<summary>
        /// Unique identifier for the error.
        ///</summary>
        [DataMember(Name = "error.id")]
        public string Id { get; set; }

        ///<summary>
        /// Error message.
        ///</summary>
        [DataMember(Name = "error.message")]
        public string Message { get; set; }

        ///<summary>
        /// Error code describing the error.
        ///</summary>
        [DataMember(Name = "error.code")]
        public string Code { get; set; }

    }
    ///<summary>
    /// Event
    /// <para />
    /// The event fields are used for context information about the log or metric event itself. A log is defined as an event containing details of something that happened. Log events must include the time at which the thing happened. Examples of log events include a process starting on a host, a network packet being sent from a source to a destination, or a network connection between a client and a server being initiated or closed. A metric is defined as an event containing one or more numerical or categorical measurements and the time at which the measurement was taken. Examples of metric events include memory pressure measured on a host, or vulnerabilities measured on a scanned host.
    ///</summary>
    public class Event 
    {
        ///<summary>
        /// Unique ID to describe the event.
        ///</summary>
        ///<example>8a4f500d</example>
        [DataMember(Name = "event.id")]
        public string Id { get; set; }

        ///<summary>
        /// The kind of the event. This gives information about what type of information the event contains, without being specific to the contents of the event.  Examples are `event`, `state`, `alarm`. Warning: In future versions of ECS, we plan to provide a list of acceptable values for this field, please use with caution.
        ///</summary>
        ///<example>state</example>
        [DataMember(Name = "event.kind")]
        public string Kind { get; set; }

        ///<summary>
        /// Event category. This contains high-level information about the contents of the event. It is more generic than `event.action`, in the sense that typically a category contains multiple actions. Warning: In future versions of ECS, we plan to provide a list of acceptable values for this field, please use with caution.
        ///</summary>
        ///<example>user-management</example>
        [DataMember(Name = "event.category")]
        public string Category { get; set; }

        ///<summary>
        /// The action captured by the event. This describes the information in the event. It is more specific than `event.category`. Examples are `group-add`, `process-started`, `file-created`. The value is normally defined by the implementer.
        ///</summary>
        ///<example>user-password-change</example>
        [DataMember(Name = "event.action")]
        public string Action { get; set; }

        ///<summary>
        /// The outcome of the event. If the event describes an action, this fields contains the outcome of that action. Examples outcomes are `success` and `failure`. Warning: In future versions of ECS, we plan to provide a list of acceptable values for this field, please use with caution.
        ///</summary>
        ///<example>success</example>
        [DataMember(Name = "event.outcome")]
        public string Outcome { get; set; }

        ///<summary>
        /// Reserved for future usage. Please avoid using this field for user data.
        ///</summary>
        [DataMember(Name = "event.type")]
        public string Type { get; set; }

        ///<summary>
        /// Name of the module this data is coming from. This information is coming from the modules used in Beats or Logstash.
        ///</summary>
        ///<example>mysql</example>
        [DataMember(Name = "event.module")]
        public string Module { get; set; }

        ///<summary>
        /// Name of the dataset. The concept of a `dataset` (fileset / metricset) is used in Beats as a subset of modules. It contains the information which is currently stored in metricset.name and metricset.module or fileset.name.
        ///</summary>
        ///<example>stats</example>
        [DataMember(Name = "event.dataset")]
        public string Dataset { get; set; }

        ///<summary>
        /// Severity describes the original severity of the event. What the different severity values mean can very different between use cases. It&#x27;s up to the implementer to make sure severities are consistent across events.
        ///</summary>
        ///<example>7</example>
        [DataMember(Name = "event.severity")]
        public long? Severity { get; set; }

        ///<summary>
        /// Raw text message of entire event. Used to demonstrate log integrity. This field is not indexed and doc_values are disabled. It cannot be searched, but it can be retrieved from `_source`.
        ///</summary>
        ///<example>Sep 19 08:26:10 host CEF:0&#124;Security&#124; threatmanager&#124;1.0&#124;100&#124; worm successfully stopped&#124;10&#124;src=10.0.0.1 dst=2.1.2.2spt=1232</example>
        [DataMember(Name = "event.original")]
        public string Original { get; set; }

        ///<summary>
        /// Hash (perhaps logstash fingerprint) of raw field to be able to demonstrate log integrity.
        ///</summary>
        ///<example>123456789012345678901234567890ABCD</example>
        [DataMember(Name = "event.hash")]
        public string Hash { get; set; }

        ///<summary>
        /// Duration of the event in nanoseconds. If event.start and event.end are known this value should be the difference between the end and start time.
        ///</summary>
        [DataMember(Name = "event.duration")]
        public long? Duration { get; set; }

        ///<summary>
        /// This field should be populated when the event&#x27;s timestamp does not include timezone information already (e.g. default Syslog timestamps). It&#x27;s optional otherwise. Acceptable timezone formats are: a canonical ID (e.g. &quot;Europe/Amsterdam&quot;), abbreviated (e.g. &quot;EST&quot;) or an HH:mm differential (e.g. &quot;-05:00&quot;).
        ///</summary>
        [DataMember(Name = "event.timezone")]
        public string Timezone { get; set; }

        ///<summary>
        /// event.created contains the date/time when the event was first read by an agent, or by your pipeline. This field is distinct from @timestamp in that @timestamp typically contain the time extracted from the original event. In most situations, these two timestamps will be slightly different. The difference can be used to calculate the delay between your source generating an event, and the time when your agent first processed it. This can be used to monitor your agent&#x27;s or pipeline&#x27;s ability to keep up with your event source. In case the two timestamps are identical, @timestamp should be used.
        ///</summary>
        [DataMember(Name = "event.created")]
        public DateTimeOffset? Created { get; set; }

        ///<summary>
        /// event.start contains the date when the event started or when the activity was first observed.
        ///</summary>
        [DataMember(Name = "event.start")]
        public DateTimeOffset? Start { get; set; }

        ///<summary>
        /// event.end contains the date when the event ended or when the activity was last observed.
        ///</summary>
        [DataMember(Name = "event.end")]
        public DateTimeOffset? End { get; set; }

        ///<summary>
        /// Risk score or priority of the event (e.g. security solutions). Use your system&#x27;s original value here.
        ///</summary>
        [DataMember(Name = "event.risk_score")]
        public float? RiskScore { get; set; }

        ///<summary>
        /// Normalized risk score or priority of the event, on a scale of 0 to 100. This is mainly useful if you use more than one system that assigns risk scores, and you want to see a normalized value across all systems.
        ///</summary>
        [DataMember(Name = "event.risk_score_norm")]
        public float? RiskScoreNorm { get; set; }

    }
    ///<summary>
    /// File
    /// <para />
    /// A file is defined as a set of information that has been created on, or has existed on a filesystem. File objects can be associated with host events, network events, and/or file events (e.g., those produced by File Integrity Monitoring [FIM] products or services). File fields provide details about the affected file associated with the event or metric.
    ///</summary>
    public class File 
    {
        ///<summary>
        /// Path to the file.
        ///</summary>
        [DataMember(Name = "file.path")]
        public string Path { get; set; }

        ///<summary>
        /// Target path for symlinks.
        ///</summary>
        [DataMember(Name = "file.target_path")]
        public string TargetPath { get; set; }

        ///<summary>
        /// File extension. This should allow easy filtering by file extensions.
        ///</summary>
        ///<example>png</example>
        [DataMember(Name = "file.extension")]
        public string Extension { get; set; }

        ///<summary>
        /// File type (file, dir, or symlink).
        ///</summary>
        [DataMember(Name = "file.type")]
        public string Type { get; set; }

        ///<summary>
        /// Device that is the source of the file.
        ///</summary>
        [DataMember(Name = "file.device")]
        public string Device { get; set; }

        ///<summary>
        /// Inode representing the file in the filesystem.
        ///</summary>
        [DataMember(Name = "file.inode")]
        public string Inode { get; set; }

        ///<summary>
        /// The user ID (UID) or security identifier (SID) of the file owner.
        ///</summary>
        [DataMember(Name = "file.uid")]
        public string Uid { get; set; }

        ///<summary>
        /// File owner&#x27;s username.
        ///</summary>
        [DataMember(Name = "file.owner")]
        public string Owner { get; set; }

        ///<summary>
        /// Primary group ID (GID) of the file.
        ///</summary>
        [DataMember(Name = "file.gid")]
        public string Gid { get; set; }

        ///<summary>
        /// Primary group name of the file.
        ///</summary>
        [DataMember(Name = "file.group")]
        public string Group { get; set; }

        ///<summary>
        /// Mode of the file in octal representation.
        ///</summary>
        ///<example>416</example>
        [DataMember(Name = "file.mode")]
        public string Mode { get; set; }

        ///<summary>
        /// File size in bytes (field is only added when `type` is `file`).
        ///</summary>
        [DataMember(Name = "file.size")]
        public long? Size { get; set; }

        ///<summary>
        /// Last time file content was modified.
        ///</summary>
        [DataMember(Name = "file.mtime")]
        public DateTimeOffset? Mtime { get; set; }

        ///<summary>
        /// Last time file metadata changed.
        ///</summary>
        [DataMember(Name = "file.ctime")]
        public DateTimeOffset? Ctime { get; set; }

    }
    ///<summary>
    /// Geo
    /// <para />
    /// Geo fields can carry data about a specific location related to an event. This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
    ///</summary>
    public class Geo 
    {
        ///<summary>
        /// Longitude and latitude.
        ///</summary>
        ///<example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "geo.location")]
        public GeoPoint Location { get; set; }

        ///<summary>
        /// Name of the continent.
        ///</summary>
        ///<example>North America</example>
        [DataMember(Name = "geo.continent_name")]
        public string ContinentName { get; set; }

        ///<summary>
        /// Country name.
        ///</summary>
        ///<example>Canada</example>
        [DataMember(Name = "geo.country_name")]
        public string CountryName { get; set; }

        ///<summary>
        /// Region name.
        ///</summary>
        ///<example>Quebec</example>
        [DataMember(Name = "geo.region_name")]
        public string RegionName { get; set; }

        ///<summary>
        /// City name.
        ///</summary>
        ///<example>Montreal</example>
        [DataMember(Name = "geo.city_name")]
        public string CityName { get; set; }

        ///<summary>
        /// Country ISO code.
        ///</summary>
        ///<example>CA</example>
        [DataMember(Name = "geo.country_iso_code")]
        public string CountryIsoCode { get; set; }

        ///<summary>
        /// Region ISO code.
        ///</summary>
        ///<example>CA-QC</example>
        [DataMember(Name = "geo.region_iso_code")]
        public string RegionIsoCode { get; set; }

        ///<summary>
        /// User-defined description of a location, at the level of granularity they care about. Could be the name of their data centers, the floor number, if this describes a local physical entity, city names. Not typically used in automated geolocation.
        ///</summary>
        ///<example>boston-dc</example>
        [DataMember(Name = "geo.name")]
        public string Name { get; set; }

    }
    ///<summary>
    /// Group
    /// <para />
    /// The group fields are meant to represent groups that are relevant to the event.
    ///</summary>
    public class Group 
    {
        ///<summary>
        /// Unique identifier for the group on the system/platform.
        ///</summary>
        [DataMember(Name = "group.id")]
        public string Id { get; set; }

        ///<summary>
        /// Name of the group.
        ///</summary>
        [DataMember(Name = "group.name")]
        public string Name { get; set; }

    }
    ///<summary>
    /// Host
    /// <para />
    /// A host is defined as a general computing instance. ECS host.* fields should be populated with details about the host on which the event happened, or from which the measurement was taken. Host types include hardware, virtual machines, Docker containers, and Kubernetes nodes.
    ///</summary>
    public class Host 
    {
        ///<summary>
        /// Longitude and latitude.
        ///</summary>
        ///<example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "host.geo.location")]
        public GeoPoint GeoLocation { get; set; }

        ///<summary>
        /// Hostname of the host. It normally contains what the `hostname` command returns on the host machine.
        ///</summary>
        [DataMember(Name = "host.hostname")]
        public string Hostname { get; set; }

        ///<summary>
        /// Operating system platform (such centos, ubuntu, windows).
        ///</summary>
        ///<example>darwin</example>
        [DataMember(Name = "host.os.platform")]
        public string OsPlatform { get; set; }

        ///<summary>
        /// Unique identifier for the group on the system/platform.
        ///</summary>
        [DataMember(Name = "host.user.group.id")]
        public string UserGroupId { get; set; }

        ///<summary>
        /// One or multiple unique identifiers of the user.
        ///</summary>
        [DataMember(Name = "host.user.id")]
        public string UserId { get; set; }

        ///<summary>
        /// Name of the continent.
        ///</summary>
        ///<example>North America</example>
        [DataMember(Name = "host.geo.continent_name")]
        public string GeoContinentName { get; set; }

        ///<summary>
        /// Name of the host. It can contain what `hostname` returns on Unix systems, the fully qualified domain name, or a name specified by the user. The sender decides which value to use.
        ///</summary>
        [DataMember(Name = "host.name")]
        public string Name { get; set; }

        ///<summary>
        /// Operating system name, without the version.
        ///</summary>
        ///<example>Mac OS X</example>
        [DataMember(Name = "host.os.name")]
        public string OsName { get; set; }

        ///<summary>
        /// Name of the group.
        ///</summary>
        [DataMember(Name = "host.user.group.name")]
        public string UserGroupName { get; set; }

        ///<summary>
        /// Short name or login of the user.
        ///</summary>
        ///<example>albert</example>
        [DataMember(Name = "host.user.name")]
        public string UserName { get; set; }

        ///<summary>
        /// Country name.
        ///</summary>
        ///<example>Canada</example>
        [DataMember(Name = "host.geo.country_name")]
        public string GeoCountryName { get; set; }

        ///<summary>
        /// Unique host id. As hostname is not always unique, use values that are meaningful in your environment. Example: The current usage of `beat.name`.
        ///</summary>
        [DataMember(Name = "host.id")]
        public string Id { get; set; }

        ///<summary>
        /// Operating system name, including the version or code name.
        ///</summary>
        ///<example>Mac OS Mojave</example>
        [DataMember(Name = "host.os.full")]
        public string OsFull { get; set; }

        ///<summary>
        /// User&#x27;s full name, if available.
        ///</summary>
        ///<example>Albert Einstein</example>
        [DataMember(Name = "host.user.full_name")]
        public string UserFullName { get; set; }

        ///<summary>
        /// Region name.
        ///</summary>
        ///<example>Quebec</example>
        [DataMember(Name = "host.geo.region_name")]
        public string GeoRegionName { get; set; }

        ///<summary>
        /// Host ip address.
        ///</summary>
        [DataMember(Name = "host.ip")]
        public IPAddress Ip { get; set; }

        ///<summary>
        /// OS family (such as redhat, debian, freebsd, windows).
        ///</summary>
        ///<example>debian</example>
        [DataMember(Name = "host.os.family")]
        public string OsFamily { get; set; }

        ///<summary>
        /// User email address.
        ///</summary>
        [DataMember(Name = "host.user.email")]
        public string UserEmail { get; set; }

        ///<summary>
        /// City name.
        ///</summary>
        ///<example>Montreal</example>
        [DataMember(Name = "host.geo.city_name")]
        public string GeoCityName { get; set; }

        ///<summary>
        /// Host mac address.
        ///</summary>
        [DataMember(Name = "host.mac")]
        public string Mac { get; set; }

        ///<summary>
        /// Operating system version as a raw string.
        ///</summary>
        ///<example>10.14.1</example>
        [DataMember(Name = "host.os.version")]
        public string OsVersion { get; set; }

        ///<summary>
        /// Unique user hash to correlate information for a user in anonymized form. Useful if `user.id` or `user.name` contain confidential information and cannot be used.
        ///</summary>
        [DataMember(Name = "host.user.hash")]
        public string UserHash { get; set; }

        ///<summary>
        /// Country ISO code.
        ///</summary>
        ///<example>CA</example>
        [DataMember(Name = "host.geo.country_iso_code")]
        public string GeoCountryIsoCode { get; set; }

        ///<summary>
        /// Operating system kernel version as a raw string.
        ///</summary>
        ///<example>4.4.0-112-generic</example>
        [DataMember(Name = "host.os.kernel")]
        public string OsKernel { get; set; }

        ///<summary>
        /// Type of host. For Cloud providers this can be the machine type like `t2.medium`. If vm, this could be the container, for example, or other information meaningful in your environment.
        ///</summary>
        [DataMember(Name = "host.type")]
        public string Type { get; set; }

        ///<summary>
        /// Operating system architecture.
        ///</summary>
        ///<example>x86_64</example>
        [DataMember(Name = "host.architecture")]
        public string Architecture { get; set; }

        ///<summary>
        /// Region ISO code.
        ///</summary>
        ///<example>CA-QC</example>
        [DataMember(Name = "host.geo.region_iso_code")]
        public string GeoRegionIsoCode { get; set; }

        ///<summary>
        /// User-defined description of a location, at the level of granularity they care about. Could be the name of their data centers, the floor number, if this describes a local physical entity, city names. Not typically used in automated geolocation.
        ///</summary>
        ///<example>boston-dc</example>
        [DataMember(Name = "host.geo.name")]
        public string GeoName { get; set; }

    }
    ///<summary>
    /// HTTP
    /// <para />
    /// Fields related to HTTP activity. Use the `url` field set to store the url of the request.
    ///</summary>
    public class Http 
    {
        ///<summary>
        /// HTTP request method. The field value must be normalized to lowercase for querying. See the documentation section &quot;Implementing ECS&quot;.
        ///</summary>
        ///<example>get, post, put</example>
        [DataMember(Name = "http.request.method")]
        public string RequestMethod { get; set; }

        ///<summary>
        /// The full HTTP request body.
        ///</summary>
        ///<example>Hello world</example>
        [DataMember(Name = "http.request.body.content")]
        public string RequestBodyContent { get; set; }

        ///<summary>
        /// Referrer for this HTTP request.
        ///</summary>
        ///<example>https://blog.example.com/</example>
        [DataMember(Name = "http.request.referrer")]
        public string RequestReferrer { get; set; }

        ///<summary>
        /// HTTP response status code.
        ///</summary>
        ///<example>404</example>
        [DataMember(Name = "http.response.status_code")]
        public long? ResponseStatusCode { get; set; }

        ///<summary>
        /// The full HTTP response body.
        ///</summary>
        ///<example>Hello world</example>
        [DataMember(Name = "http.response.body.content")]
        public string ResponseBodyContent { get; set; }

        ///<summary>
        /// HTTP version.
        ///</summary>
        ///<example>1.1</example>
        [DataMember(Name = "http.version")]
        public string Version { get; set; }

        ///<summary>
        /// Total size in bytes of the request (body and headers).
        ///</summary>
        ///<example>1437</example>
        [DataMember(Name = "http.request.bytes")]
        public long? RequestBytes { get; set; }

        ///<summary>
        /// Size in bytes of the request body.
        ///</summary>
        ///<example>887</example>
        [DataMember(Name = "http.request.body.bytes")]
        public long? RequestBodyBytes { get; set; }

        ///<summary>
        /// Total size in bytes of the response (body and headers).
        ///</summary>
        ///<example>1437</example>
        [DataMember(Name = "http.response.bytes")]
        public long? ResponseBytes { get; set; }

        ///<summary>
        /// Size in bytes of the response body.
        ///</summary>
        ///<example>887</example>
        [DataMember(Name = "http.response.body.bytes")]
        public long? ResponseBodyBytes { get; set; }

    }
    ///<summary>
    /// Log
    /// <para />
    /// Fields which are specific to log events.
    ///</summary>
    public class Log 
    {
        ///<summary>
        /// Original log level of the log event. Some examples are `warn`, `error`, `i`.
        ///</summary>
        ///<example>err</example>
        [DataMember(Name = "log.level")]
        public string Level { get; set; }

        ///<summary>
        /// This is the original log message and contains the full log message before splitting it up in multiple parts. In contrast to the `message` field which can contain an extracted part of the log message, this field contains the original, full log message. It can have already some modifications applied like encoding or new lines removed to clean up the log message. This field is not indexed and doc_values are disabled so it can&#x27;t be queried but the value can be retrieved from `_source`.
        ///</summary>
        ///<example>Sep 19 08:26:10 localhost My log</example>
        [DataMember(Name = "log.original")]
        public string Original { get; set; }

    }
    ///<summary>
    /// Network
    /// <para />
    /// The network is defined as the communication path over which a host or network event happens. The network.* fields should be populated with details about the network activity associated with an event.
    ///</summary>
    public class Network 
    {
        ///<summary>
        /// Name given by operators to sections of their network.
        ///</summary>
        ///<example>Guest Wifi</example>
        [DataMember(Name = "network.name")]
        public string Name { get; set; }

        ///<summary>
        /// In the OSI Model this would be the Network Layer. ipv4, ipv6, ipsec, pim, etc The field value must be normalized to lowercase for querying. See the documentation section &quot;Implementing ECS&quot;.
        ///</summary>
        ///<example>ipv4</example>
        [DataMember(Name = "network.type")]
        public string Type { get; set; }

        ///<summary>
        /// IANA Protocol Number (https://www.iana.org/assignments/protocol-numbers/protocol-numbers.xhtml). Standardized list of protocols. This aligns well with NetFlow and sFlow related logs which use the IANA Protocol Number.
        ///</summary>
        ///<example>6</example>
        [DataMember(Name = "network.iana_number")]
        public string IanaNumber { get; set; }

        ///<summary>
        /// Same as network.iana_number, but instead using the Keyword name of the transport layer (udp, tcp, ipv6-icmp, etc.) The field value must be normalized to lowercase for querying. See the documentation section &quot;Implementing ECS&quot;.
        ///</summary>
        ///<example>tcp</example>
        [DataMember(Name = "network.transport")]
        public string Transport { get; set; }

        ///<summary>
        /// A name given to an application level protocol. This can be arbitrarily assigned for things like microservices, but also apply to things like skype, icq, facebook, twitter. This would be used in situations where the vendor or service can be decoded such as from the source/dest IP owners, ports, or wire format. The field value must be normalized to lowercase for querying. See the documentation section &quot;Implementing ECS&quot;.
        ///</summary>
        ///<example>aim</example>
        [DataMember(Name = "network.application")]
        public string Application { get; set; }

        ///<summary>
        /// L7 Network protocol name. ex. http, lumberjack, transport protocol. The field value must be normalized to lowercase for querying. See the documentation section &quot;Implementing ECS&quot;.
        ///</summary>
        ///<example>http</example>
        [DataMember(Name = "network.protocol")]
        public string Protocol { get; set; }

        ///<summary>
        /// Direction of the network traffic. Recommended values are:   * inbound   * outbound   * internal   * external   * unknown  When mapping events from a host-based monitoring context, populate this field from the host&#x27;s point of view. When mapping events from a network or perimeter-based monitoring context, populate this field from the point of view of your network perimeter.
        ///</summary>
        ///<example>inbound</example>
        [DataMember(Name = "network.direction")]
        public string Direction { get; set; }

        ///<summary>
        /// Host IP address when the source IP address is the proxy.
        ///</summary>
        ///<example>192.1.1.2</example>
        [DataMember(Name = "network.forwarded_ip")]
        public IPAddress ForwardedIp { get; set; }

        ///<summary>
        /// A hash of source and destination IPs and ports, as well as the protocol used in a communication. This is a tool-agnostic standard to identify flows. Learn more at https://github.com/corelight/community-id-spec.
        ///</summary>
        ///<example>1:hO+sN4H+MG5MY/8hIrXPqc4ZQz0=</example>
        [DataMember(Name = "network.community_id")]
        public string CommunityId { get; set; }

        ///<summary>
        /// Total bytes transferred in both directions. If `source.bytes` and `destination.bytes` are known, `network.bytes` is their sum.
        ///</summary>
        ///<example>368</example>
        [DataMember(Name = "network.bytes")]
        public long? Bytes { get; set; }

        ///<summary>
        /// Total packets transferred in both directions. If `source.packets` and `destination.packets` are known, `network.packets` is their sum.
        ///</summary>
        ///<example>24</example>
        [DataMember(Name = "network.packets")]
        public long? Packets { get; set; }

    }
    ///<summary>
    /// Observer
    /// <para />
    /// An observer is defined as a special network, security, or application device used to detect, observe, or create network, security, or application-related events and metrics. This could be a custom hardware appliance or a server that has been configured to run special network, security, or application software. Examples include firewalls, intrusion detection/prevention systems, network monitoring sensors, web application firewalls, data loss prevention systems, and APM servers. The observer.* fields shall be populated with details of the system, if any, that detects, observes and/or creates a network, security, or application event or metric. Message queues and ETL components used in processing events or metrics are not considered observers in ECS.
    ///</summary>
    public class Observer 
    {
        ///<summary>
        /// Longitude and latitude.
        ///</summary>
        ///<example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "observer.geo.location")]
        public GeoPoint GeoLocation { get; set; }

        ///<summary>
        /// MAC address of the observer
        ///</summary>
        [DataMember(Name = "observer.mac")]
        public string Mac { get; set; }

        ///<summary>
        /// Operating system platform (such centos, ubuntu, windows).
        ///</summary>
        ///<example>darwin</example>
        [DataMember(Name = "observer.os.platform")]
        public string OsPlatform { get; set; }

        ///<summary>
        /// Name of the continent.
        ///</summary>
        ///<example>North America</example>
        [DataMember(Name = "observer.geo.continent_name")]
        public string GeoContinentName { get; set; }

        ///<summary>
        /// IP address of the observer.
        ///</summary>
        [DataMember(Name = "observer.ip")]
        public IPAddress Ip { get; set; }

        ///<summary>
        /// Operating system name, without the version.
        ///</summary>
        ///<example>Mac OS X</example>
        [DataMember(Name = "observer.os.name")]
        public string OsName { get; set; }

        ///<summary>
        /// Country name.
        ///</summary>
        ///<example>Canada</example>
        [DataMember(Name = "observer.geo.country_name")]
        public string GeoCountryName { get; set; }

        ///<summary>
        /// Hostname of the observer.
        ///</summary>
        [DataMember(Name = "observer.hostname")]
        public string Hostname { get; set; }

        ///<summary>
        /// Operating system name, including the version or code name.
        ///</summary>
        ///<example>Mac OS Mojave</example>
        [DataMember(Name = "observer.os.full")]
        public string OsFull { get; set; }

        ///<summary>
        /// Region name.
        ///</summary>
        ///<example>Quebec</example>
        [DataMember(Name = "observer.geo.region_name")]
        public string GeoRegionName { get; set; }

        ///<summary>
        /// OS family (such as redhat, debian, freebsd, windows).
        ///</summary>
        ///<example>debian</example>
        [DataMember(Name = "observer.os.family")]
        public string OsFamily { get; set; }

        ///<summary>
        /// observer vendor information.
        ///</summary>
        [DataMember(Name = "observer.vendor")]
        public string Vendor { get; set; }

        ///<summary>
        /// City name.
        ///</summary>
        ///<example>Montreal</example>
        [DataMember(Name = "observer.geo.city_name")]
        public string GeoCityName { get; set; }

        ///<summary>
        /// Operating system version as a raw string.
        ///</summary>
        ///<example>10.14.1</example>
        [DataMember(Name = "observer.os.version")]
        public string OsVersion { get; set; }

        ///<summary>
        /// Observer version.
        ///</summary>
        [DataMember(Name = "observer.version")]
        public string Version { get; set; }

        ///<summary>
        /// Country ISO code.
        ///</summary>
        ///<example>CA</example>
        [DataMember(Name = "observer.geo.country_iso_code")]
        public string GeoCountryIsoCode { get; set; }

        ///<summary>
        /// Operating system kernel version as a raw string.
        ///</summary>
        ///<example>4.4.0-112-generic</example>
        [DataMember(Name = "observer.os.kernel")]
        public string OsKernel { get; set; }

        ///<summary>
        /// Observer serial number.
        ///</summary>
        [DataMember(Name = "observer.serial_number")]
        public string SerialNumber { get; set; }

        ///<summary>
        /// Region ISO code.
        ///</summary>
        ///<example>CA-QC</example>
        [DataMember(Name = "observer.geo.region_iso_code")]
        public string GeoRegionIsoCode { get; set; }

        ///<summary>
        /// The type of the observer the data is coming from. There is no predefined list of observer types. Some examples are `forwarder`, `firewall`, `ids`, `ips`, `proxy`, `poller`, `sensor`, `APM server`.
        ///</summary>
        ///<example>firewall</example>
        [DataMember(Name = "observer.type")]
        public string Type { get; set; }

        ///<summary>
        /// User-defined description of a location, at the level of granularity they care about. Could be the name of their data centers, the floor number, if this describes a local physical entity, city names. Not typically used in automated geolocation.
        ///</summary>
        ///<example>boston-dc</example>
        [DataMember(Name = "observer.geo.name")]
        public string GeoName { get; set; }

    }
    ///<summary>
    /// Organization
    /// <para />
    /// The organization fields enrich data with information about the company or entity the data is associated with. These fields help you arrange or filter data stored in an index by one or multiple organizations.
    ///</summary>
    public class Organization 
    {
        ///<summary>
        /// Organization name.
        ///</summary>
        [DataMember(Name = "organization.name")]
        public string Name { get; set; }

        ///<summary>
        /// Unique identifier for the organization.
        ///</summary>
        [DataMember(Name = "organization.id")]
        public string Id { get; set; }

    }
    ///<summary>
    /// Operating System
    /// <para />
    /// The OS fields contain information about the operating system.
    ///</summary>
    public class Os 
    {
        ///<summary>
        /// Operating system platform (such centos, ubuntu, windows).
        ///</summary>
        ///<example>darwin</example>
        [DataMember(Name = "os.platform")]
        public string Platform { get; set; }

        ///<summary>
        /// Operating system name, without the version.
        ///</summary>
        ///<example>Mac OS X</example>
        [DataMember(Name = "os.name")]
        public string Name { get; set; }

        ///<summary>
        /// Operating system name, including the version or code name.
        ///</summary>
        ///<example>Mac OS Mojave</example>
        [DataMember(Name = "os.full")]
        public string Full { get; set; }

        ///<summary>
        /// OS family (such as redhat, debian, freebsd, windows).
        ///</summary>
        ///<example>debian</example>
        [DataMember(Name = "os.family")]
        public string Family { get; set; }

        ///<summary>
        /// Operating system version as a raw string.
        ///</summary>
        ///<example>10.14.1</example>
        [DataMember(Name = "os.version")]
        public string Version { get; set; }

        ///<summary>
        /// Operating system kernel version as a raw string.
        ///</summary>
        ///<example>4.4.0-112-generic</example>
        [DataMember(Name = "os.kernel")]
        public string Kernel { get; set; }

    }
    ///<summary>
    /// Process
    /// <para />
    /// These fields contain information about a process. These fields can help you correlate metrics information with a process id/name from a log message.  The `process.pid` often stays in the metric itself and is copied to the global field for correlation.
    ///</summary>
    public class Process 
    {
        ///<summary>
        /// Process id.
        ///</summary>
        ///<example>4242</example>
        [DataMember(Name = "process.pid")]
        public long? Pid { get; set; }

        ///<summary>
        /// Process name. Sometimes called program name or similar.
        ///</summary>
        ///<example>ssh</example>
        [DataMember(Name = "process.name")]
        public string Name { get; set; }

        ///<summary>
        /// Parent process&#x27; pid.
        ///</summary>
        ///<example>4241</example>
        [DataMember(Name = "process.ppid")]
        public long? Ppid { get; set; }

        ///<summary>
        /// Array of process arguments. May be filtered to protect sensitive information.
        ///</summary>
        ///<example>["ssh","-l","user","10.0.0.16"]</example>
        [DataMember(Name = "process.args")]
        public string[] Args { get; set; }

        ///<summary>
        /// Absolute path to the process executable.
        ///</summary>
        ///<example>/usr/bin/ssh</example>
        [DataMember(Name = "process.executable")]
        public string Executable { get; set; }

        ///<summary>
        /// Process title. The proctitle, some times the same as process name. Can also be different: for example a browser setting its title to the web page currently opened.
        ///</summary>
        [DataMember(Name = "process.title")]
        public string Title { get; set; }

        ///<summary>
        /// Thread ID.
        ///</summary>
        ///<example>4242</example>
        [DataMember(Name = "process.thread.id")]
        public long? ThreadId { get; set; }

        ///<summary>
        /// The time the process started.
        ///</summary>
        ///<example>2016-05-23T08:05:34.853Z</example>
        [DataMember(Name = "process.start")]
        public DateTimeOffset? Start { get; set; }

        ///<summary>
        /// The working directory of the process.
        ///</summary>
        ///<example>/home/alice</example>
        [DataMember(Name = "process.working_directory")]
        public string WorkingDirectory { get; set; }

    }
    ///<summary>
    /// Related
    /// <para />
    /// This field set is meant to facilitate pivoting around a piece of data. Some pieces of information can be seen in many places in an ECS event. To facilitate searching for them, store an array of all seen values to their corresponding field in `related.`. A concrete example is IP addresses, which can be under host, observer, source, destination, client, server, and network.forwarded_ip. If you append all IPs to `related.ip`, you can then search for a given IP trivially, no matter where it appeared, by querying `related.ip:a.b.c.d`.
    ///</summary>
    public class Related 
    {
        ///<summary>
        /// All of the IPs seen on your event.
        ///</summary>
        [DataMember(Name = "related.ip")]
        public IPAddress Ip { get; set; }

    }
    ///<summary>
    /// Server
    /// <para />
    /// A Server is defined as the responder in a network connection for events regarding sessions, connections, or bidirectional flow records. For TCP events, the server is the receiver of the initial SYN packet(s) of the TCP connection. For other protocols, the server is generally the responder in the network transaction. Some systems actually use the term &quot;responder&quot; to refer the server in TCP connections. The server fields describe details about the system acting as the server in the network event. Server fields are usually populated in conjunction with client fields. Server fields are generally not populated for packet-level events. Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
    ///</summary>
    public class Server 
    {
        ///<summary>
        /// Some event server addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field. Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
        ///</summary>
        [DataMember(Name = "server.address")]
        public string Address { get; set; }

        ///<summary>
        /// Longitude and latitude.
        ///</summary>
        ///<example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "server.geo.location")]
        public GeoPoint GeoLocation { get; set; }

        ///<summary>
        /// Unique identifier for the group on the system/platform.
        ///</summary>
        [DataMember(Name = "server.user.group.id")]
        public string UserGroupId { get; set; }

        ///<summary>
        /// One or multiple unique identifiers of the user.
        ///</summary>
        [DataMember(Name = "server.user.id")]
        public string UserId { get; set; }

        ///<summary>
        /// Name of the continent.
        ///</summary>
        ///<example>North America</example>
        [DataMember(Name = "server.geo.continent_name")]
        public string GeoContinentName { get; set; }

        ///<summary>
        /// IP address of the server. Can be one or multiple IPv4 or IPv6 addresses.
        ///</summary>
        [DataMember(Name = "server.ip")]
        public IPAddress Ip { get; set; }

        ///<summary>
        /// Name of the group.
        ///</summary>
        [DataMember(Name = "server.user.group.name")]
        public string UserGroupName { get; set; }

        ///<summary>
        /// Short name or login of the user.
        ///</summary>
        ///<example>albert</example>
        [DataMember(Name = "server.user.name")]
        public string UserName { get; set; }

        ///<summary>
        /// Country name.
        ///</summary>
        ///<example>Canada</example>
        [DataMember(Name = "server.geo.country_name")]
        public string GeoCountryName { get; set; }

        ///<summary>
        /// Port of the server.
        ///</summary>
        [DataMember(Name = "server.port")]
        public long? Port { get; set; }

        ///<summary>
        /// User&#x27;s full name, if available.
        ///</summary>
        ///<example>Albert Einstein</example>
        [DataMember(Name = "server.user.full_name")]
        public string UserFullName { get; set; }

        ///<summary>
        /// Region name.
        ///</summary>
        ///<example>Quebec</example>
        [DataMember(Name = "server.geo.region_name")]
        public string GeoRegionName { get; set; }

        ///<summary>
        /// MAC address of the server.
        ///</summary>
        [DataMember(Name = "server.mac")]
        public string Mac { get; set; }

        ///<summary>
        /// User email address.
        ///</summary>
        [DataMember(Name = "server.user.email")]
        public string UserEmail { get; set; }

        ///<summary>
        /// Server domain.
        ///</summary>
        [DataMember(Name = "server.domain")]
        public string Domain { get; set; }

        ///<summary>
        /// City name.
        ///</summary>
        ///<example>Montreal</example>
        [DataMember(Name = "server.geo.city_name")]
        public string GeoCityName { get; set; }

        ///<summary>
        /// Unique user hash to correlate information for a user in anonymized form. Useful if `user.id` or `user.name` contain confidential information and cannot be used.
        ///</summary>
        [DataMember(Name = "server.user.hash")]
        public string UserHash { get; set; }

        ///<summary>
        /// Bytes sent from the server to the client.
        ///</summary>
        ///<example>184</example>
        [DataMember(Name = "server.bytes")]
        public long? Bytes { get; set; }

        ///<summary>
        /// Country ISO code.
        ///</summary>
        ///<example>CA</example>
        [DataMember(Name = "server.geo.country_iso_code")]
        public string GeoCountryIsoCode { get; set; }

        ///<summary>
        /// Region ISO code.
        ///</summary>
        ///<example>CA-QC</example>
        [DataMember(Name = "server.geo.region_iso_code")]
        public string GeoRegionIsoCode { get; set; }

        ///<summary>
        /// Packets sent from the server to the client.
        ///</summary>
        ///<example>12</example>
        [DataMember(Name = "server.packets")]
        public long? Packets { get; set; }

        ///<summary>
        /// User-defined description of a location, at the level of granularity they care about. Could be the name of their data centers, the floor number, if this describes a local physical entity, city names. Not typically used in automated geolocation.
        ///</summary>
        ///<example>boston-dc</example>
        [DataMember(Name = "server.geo.name")]
        public string GeoName { get; set; }

    }
    ///<summary>
    /// Service
    /// <para />
    /// The service fields describe the service for or from which the data was collected. These fields help you find and correlate logs for a specific service and version.
    ///</summary>
    public class Service 
    {
        ///<summary>
        /// Unique identifier of the running service. If the service is comprised of many nodes, the `service.id` should be the same for all nodes. This id should uniquely identify the service. This makes it possible to correlate logs and metrics for one specific service, no matter which particular node emitted the event. Note that if you need to see the events from one specific host of the service, you should filter on that `host.name` or `host.id` instead.
        ///</summary>
        ///<example>d37e5ebfe0ae6c4972dbe9f0174a1637bb8247f6</example>
        [DataMember(Name = "service.id")]
        public string Id { get; set; }

        ///<summary>
        /// Name of the service data is collected from. The name of the service is normally user given. This allows if two instances of the same service are running on the same machine they can be differentiated by the `service.name`. Also it allows for distributed services that run on multiple hosts to correlate the related instances based on the name. In the case of Elasticsearch the service.name could contain the cluster name. For Beats the service.name is by default a copy of the `service.type` field if no name is specified.
        ///</summary>
        ///<example>elasticsearch-metrics</example>
        [DataMember(Name = "service.name")]
        public string Name { get; set; }

        ///<summary>
        /// The type of the service data is collected from. The type can be used to group and correlate logs and metrics from one service type. Example: If logs or metrics are collected from Elasticsearch, `service.type` would be `elasticsearch`.
        ///</summary>
        ///<example>elasticsearch</example>
        [DataMember(Name = "service.type")]
        public string Type { get; set; }

        ///<summary>
        /// Current state of the service.
        ///</summary>
        [DataMember(Name = "service.state")]
        public string State { get; set; }

        ///<summary>
        /// Version of the service the data was collected from. This allows to look at a data set only for a specific version of a service.
        ///</summary>
        ///<example>3.2.4</example>
        [DataMember(Name = "service.version")]
        public string Version { get; set; }

        ///<summary>
        /// Ephemeral identifier of this service (if one exists). This id normally changes across restarts, but `service.id` does not.
        ///</summary>
        ///<example>8a4f500f</example>
        [DataMember(Name = "service.ephemeral_id")]
        public string EphemeralId { get; set; }

    }
    ///<summary>
    /// Source
    /// <para />
    /// Source fields describe details about the source of a packet/event. Source fields are usually populated in conjunction with destination fields.
    ///</summary>
    public class Source 
    {
        ///<summary>
        /// Some event source addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field. Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
        ///</summary>
        [DataMember(Name = "source.address")]
        public string Address { get; set; }

        ///<summary>
        /// Longitude and latitude.
        ///</summary>
        ///<example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "source.geo.location")]
        public GeoPoint GeoLocation { get; set; }

        ///<summary>
        /// Unique identifier for the group on the system/platform.
        ///</summary>
        [DataMember(Name = "source.user.group.id")]
        public string UserGroupId { get; set; }

        ///<summary>
        /// One or multiple unique identifiers of the user.
        ///</summary>
        [DataMember(Name = "source.user.id")]
        public string UserId { get; set; }

        ///<summary>
        /// Name of the continent.
        ///</summary>
        ///<example>North America</example>
        [DataMember(Name = "source.geo.continent_name")]
        public string GeoContinentName { get; set; }

        ///<summary>
        /// IP address of the source. Can be one or multiple IPv4 or IPv6 addresses.
        ///</summary>
        [DataMember(Name = "source.ip")]
        public IPAddress Ip { get; set; }

        ///<summary>
        /// Name of the group.
        ///</summary>
        [DataMember(Name = "source.user.group.name")]
        public string UserGroupName { get; set; }

        ///<summary>
        /// Short name or login of the user.
        ///</summary>
        ///<example>albert</example>
        [DataMember(Name = "source.user.name")]
        public string UserName { get; set; }

        ///<summary>
        /// Country name.
        ///</summary>
        ///<example>Canada</example>
        [DataMember(Name = "source.geo.country_name")]
        public string GeoCountryName { get; set; }

        ///<summary>
        /// Port of the source.
        ///</summary>
        [DataMember(Name = "source.port")]
        public long? Port { get; set; }

        ///<summary>
        /// User&#x27;s full name, if available.
        ///</summary>
        ///<example>Albert Einstein</example>
        [DataMember(Name = "source.user.full_name")]
        public string UserFullName { get; set; }

        ///<summary>
        /// Region name.
        ///</summary>
        ///<example>Quebec</example>
        [DataMember(Name = "source.geo.region_name")]
        public string GeoRegionName { get; set; }

        ///<summary>
        /// MAC address of the source.
        ///</summary>
        [DataMember(Name = "source.mac")]
        public string Mac { get; set; }

        ///<summary>
        /// User email address.
        ///</summary>
        [DataMember(Name = "source.user.email")]
        public string UserEmail { get; set; }

        ///<summary>
        /// Source domain.
        ///</summary>
        [DataMember(Name = "source.domain")]
        public string Domain { get; set; }

        ///<summary>
        /// City name.
        ///</summary>
        ///<example>Montreal</example>
        [DataMember(Name = "source.geo.city_name")]
        public string GeoCityName { get; set; }

        ///<summary>
        /// Unique user hash to correlate information for a user in anonymized form. Useful if `user.id` or `user.name` contain confidential information and cannot be used.
        ///</summary>
        [DataMember(Name = "source.user.hash")]
        public string UserHash { get; set; }

        ///<summary>
        /// Bytes sent from the source to the destination.
        ///</summary>
        ///<example>184</example>
        [DataMember(Name = "source.bytes")]
        public long? Bytes { get; set; }

        ///<summary>
        /// Country ISO code.
        ///</summary>
        ///<example>CA</example>
        [DataMember(Name = "source.geo.country_iso_code")]
        public string GeoCountryIsoCode { get; set; }

        ///<summary>
        /// Region ISO code.
        ///</summary>
        ///<example>CA-QC</example>
        [DataMember(Name = "source.geo.region_iso_code")]
        public string GeoRegionIsoCode { get; set; }

        ///<summary>
        /// Packets sent from the source to the destination.
        ///</summary>
        ///<example>12</example>
        [DataMember(Name = "source.packets")]
        public long? Packets { get; set; }

        ///<summary>
        /// User-defined description of a location, at the level of granularity they care about. Could be the name of their data centers, the floor number, if this describes a local physical entity, city names. Not typically used in automated geolocation.
        ///</summary>
        ///<example>boston-dc</example>
        [DataMember(Name = "source.geo.name")]
        public string GeoName { get; set; }

    }
    ///<summary>
    /// URL
    /// <para />
    /// URL fields provide support for complete or partial URLs, and supports the breaking down into scheme, domain, path, and so on.
    ///</summary>
    public class Url 
    {
        ///<summary>
        /// Unmodified original url as seen in the event source. Note that in network monitoring, the observed URL may be a full URL, whereas in access logs, the URL is often just represented as a path. This field is meant to represent the URL as it was observed, complete or not.
        ///</summary>
        ///<example>https://www.elastic.co:443/search?q=elasticsearch#top or /search?q=elasticsearch</example>
        [DataMember(Name = "url.original")]
        public string Original { get; set; }

        ///<summary>
        /// If full URLs are important to your use case, they should be stored in `url.full`, whether this field is reconstructed or present in the event source.
        ///</summary>
        ///<example>https://www.elastic.co:443/search?q=elasticsearch#top</example>
        [DataMember(Name = "url.full")]
        public string Full { get; set; }

        ///<summary>
        /// Scheme of the request, such as &quot;https&quot;. Note: The `:` is not part of the scheme.
        ///</summary>
        ///<example>https</example>
        [DataMember(Name = "url.scheme")]
        public string Scheme { get; set; }

        ///<summary>
        /// Domain of the url, such as &quot;www.elastic.co&quot;. In some cases a URL may refer to an IP and/or port directly, without a domain name. In this case, the IP address would go to the `domain` field.
        ///</summary>
        ///<example>www.elastic.co</example>
        [DataMember(Name = "url.domain")]
        public string Domain { get; set; }

        ///<summary>
        /// Port of the request, such as 443.
        ///</summary>
        ///<example>443</example>
        [DataMember(Name = "url.port")]
        public long? Port { get; set; }

        ///<summary>
        /// Path of the request, such as &quot;/search&quot;.
        ///</summary>
        [DataMember(Name = "url.path")]
        public string Path { get; set; }

        ///<summary>
        /// The query field describes the query string of the request, such as &quot;q=elasticsearch&quot;. The `?` is excluded from the query string. If a URL contains no `?`, there is no query field. If there is a `?` but no query, the query field exists with an empty string. The `exists` query can be used to differentiate between the two cases.
        ///</summary>
        [DataMember(Name = "url.query")]
        public string Query { get; set; }

        ///<summary>
        /// Portion of the url after the `#`, such as &quot;top&quot;. The `#` is not part of the fragment.
        ///</summary>
        [DataMember(Name = "url.fragment")]
        public string Fragment { get; set; }

        ///<summary>
        /// Username of the request.
        ///</summary>
        [DataMember(Name = "url.username")]
        public string Username { get; set; }

        ///<summary>
        /// Password of the request.
        ///</summary>
        [DataMember(Name = "url.password")]
        public string Password { get; set; }

    }
    ///<summary>
    /// User
    /// <para />
    /// The user fields describe information about the user that is relevant to the event. Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
    ///</summary>
    public class User 
    {
        ///<summary>
        /// Unique identifier for the group on the system/platform.
        ///</summary>
        [DataMember(Name = "user.group.id")]
        public string GroupId { get; set; }

        ///<summary>
        /// One or multiple unique identifiers of the user.
        ///</summary>
        [DataMember(Name = "user.id")]
        public string Id { get; set; }

        ///<summary>
        /// Name of the group.
        ///</summary>
        [DataMember(Name = "user.group.name")]
        public string GroupName { get; set; }

        ///<summary>
        /// Short name or login of the user.
        ///</summary>
        ///<example>albert</example>
        [DataMember(Name = "user.name")]
        public string Name { get; set; }

        ///<summary>
        /// User&#x27;s full name, if available.
        ///</summary>
        ///<example>Albert Einstein</example>
        [DataMember(Name = "user.full_name")]
        public string FullName { get; set; }

        ///<summary>
        /// User email address.
        ///</summary>
        [DataMember(Name = "user.email")]
        public string Email { get; set; }

        ///<summary>
        /// Unique user hash to correlate information for a user in anonymized form. Useful if `user.id` or `user.name` contain confidential information and cannot be used.
        ///</summary>
        [DataMember(Name = "user.hash")]
        public string Hash { get; set; }

    }
    ///<summary>
    /// User agent
    /// <para />
    /// The user_agent fields normally come from a browser request. They often show up in web service logs coming from the parsed user agent string.
    ///</summary>
    public class UserAgent 
    {
        ///<summary>
        /// Unparsed version of the user_agent.
        ///</summary>
        ///<example>Mozilla/5.0 (iPhone; CPU iPhone OS 12_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/12.0 Mobile/15E148 Safari/604.1</example>
        [DataMember(Name = "user_agent.original")]
        public string Original { get; set; }

        ///<summary>
        /// Operating system platform (such centos, ubuntu, windows).
        ///</summary>
        ///<example>darwin</example>
        [DataMember(Name = "user_agent.os.platform")]
        public string OsPlatform { get; set; }

        ///<summary>
        /// Name of the user agent.
        ///</summary>
        ///<example>Safari</example>
        [DataMember(Name = "user_agent.name")]
        public string Name { get; set; }

        ///<summary>
        /// Operating system name, without the version.
        ///</summary>
        ///<example>Mac OS X</example>
        [DataMember(Name = "user_agent.os.name")]
        public string OsName { get; set; }

        ///<summary>
        /// Operating system name, including the version or code name.
        ///</summary>
        ///<example>Mac OS Mojave</example>
        [DataMember(Name = "user_agent.os.full")]
        public string OsFull { get; set; }

        ///<summary>
        /// Version of the user agent.
        ///</summary>
        ///<example>12.0</example>
        [DataMember(Name = "user_agent.version")]
        public string Version { get; set; }

        ///<summary>
        /// Name of the device.
        ///</summary>
        ///<example>iPhone</example>
        [DataMember(Name = "user_agent.device.name")]
        public string DeviceName { get; set; }

        ///<summary>
        /// OS family (such as redhat, debian, freebsd, windows).
        ///</summary>
        ///<example>debian</example>
        [DataMember(Name = "user_agent.os.family")]
        public string OsFamily { get; set; }

        ///<summary>
        /// Operating system version as a raw string.
        ///</summary>
        ///<example>10.14.1</example>
        [DataMember(Name = "user_agent.os.version")]
        public string OsVersion { get; set; }

        ///<summary>
        /// Operating system kernel version as a raw string.
        ///</summary>
        ///<example>4.4.0-112-generic</example>
        [DataMember(Name = "user_agent.os.kernel")]
        public string OsKernel { get; set; }

    }
}