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

namespace Elastic
{
    /// <summary>
    /// Elastic Common Schema for version 1.0.
    /// <para/>
    /// The Elastic Common Schema (ECS) defines a common set of fields for ingesting data into Elasticsearch.
    /// A common schema helps you correlate data from sources like logs and metrics or IT operations analytics
    /// and security analytics.
    /// <para/>
    /// https://github.com/elastic/ecs
    /// </summary>
    public class CommonSchema
    {
        /// <summary>
        /// The agent fields contain the data about the software entity, if any, that collects, detects, or observes events on a host, or takes measurements on a host.<para/>Examples include Beats. Agents may also run on observers. ECS agent.* fields shall be populated with details of the agent running on the host or observer where the event happened or the measurement was taken.
        /// </summary>
        [DataMember(Name = "agent")]
        public Agent Agent { get; set; }

        /// <summary>
        /// A client is defined as the initiator of a network connection for events regarding sessions, connections, or bidirectional flow records.<para/>For TCP events, the client is the initiator of the TCP connection that sends the SYN packet(s). For other protocols, the client is generally the initiator or requestor in the network transaction. Some systems use the term "originator" to refer the client in TCP connections. The client fields describe details about the system acting as the client in the network event. Client fields are usually populated in conjunction with server fields. Client fields are generally not populated for packet-level events.<para/>Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
        /// </summary>
        [DataMember(Name = "client")]
        public Client Client { get; set; }

        /// <summary>
        /// Fields related to the cloud or infrastructure the events are coming from.
        /// </summary>
        [DataMember(Name = "cloud")]
        public Cloud Cloud { get; set; }

        /// <summary>
        /// Container fields are used for meta information about the specific container that is the source of information.<para/>These fields help correlate data based containers from any runtime.
        /// </summary>
        [DataMember(Name = "container")]
        public Container Container { get; set; }

        /// <summary>
        /// Destination fields describe details about the destination of a packet/event.<para/>Destination fields are usually populated in conjunction with source fields.
        /// </summary>
        [DataMember(Name = "destination")]
        public Destination Destination { get; set; }

        /// <summary>
        /// Meta-information specific to ECS.
        /// </summary>
        [DataMember(Name = "ecs")]
        public Ecs Ecs { get; set; }

        /// <summary>
        /// These fields can represent errors of any kind.<para/>Use them for errors that happen while fetching events or in cases where the event itself contains an error.
        /// </summary>
        [DataMember(Name = "error")]
        public Error Error { get; set; }

        /// <summary>
        /// The event fields are used for context information about the log or metric event itself.<para/>A log is defined as an event containing details of something that happened. Log events must include the time at which the thing happened. Examples of log events include a process starting on a host, a network packet being sent from a source to a destination, or a network connection between a client and a server being initiated or closed. A metric is defined as an event containing one or more numerical or categorical measurements and the time at which the measurement was taken. Examples of metric events include memory pressure measured on a host, or vulnerabilities measured on a scanned host.
        /// </summary>
        [DataMember(Name = "event")]
        public Event Event { get; set; }

        /// <summary>
        /// A file is defined as a set of information that has been created on, or has existed on a filesystem.<para/>File objects can be associated with host events, network events, and/or file events (e.g., those produced by File Integrity Monitoring [FIM] products or services). File fields provide details about the affected file associated with the event or metric.
        /// </summary>
        [DataMember(Name = "file")]
        public File File { get; set; }

        /// <summary>
        /// Geo fields can carry data about a specific location related to an event.<para/>This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
        /// </summary>
        [DataMember(Name = "geo")]
        public Geo Geo { get; set; }

        /// <summary>
        /// The group fields are meant to represent groups that are relevant to the event.
        /// </summary>
        [DataMember(Name = "group")]
        public Group Group { get; set; }

        /// <summary>
        /// A host is defined as a general computing instance.<para/>ECS host.* fields should be populated with details about the host on which the event happened, or from which the measurement was taken. Host types include hardware, virtual machines, Docker containers, and Kubernetes nodes.
        /// </summary>
        [DataMember(Name = "host")]
        public Host Host { get; set; }

        /// <summary>
        /// Fields related to HTTP activity. Use the `url` field set to store the url of the request.
        /// </summary>
        [DataMember(Name = "http")]
        public Http Http { get; set; }

        /// <summary>
        /// Fields which are specific to log events.
        /// </summary>
        [DataMember(Name = "log")]
        public Log Log { get; set; }

        /// <summary>
        /// The network is defined as the communication path over which a host or network event happens.<para/>The network.* fields should be populated with details about the network activity associated with an event.
        /// </summary>
        [DataMember(Name = "network")]
        public Network Network { get; set; }

        /// <summary>
        /// An observer is defined as a special network, security, or application device used to detect, observe, or create network, security, or application-related events and metrics.<para/>This could be a custom hardware appliance or a server that has been configured to run special network, security, or application software. Examples include firewalls, intrusion detection/prevention systems, network monitoring sensors, web application firewalls, data loss prevention systems, and APM servers. The observer.* fields shall be populated with details of the system, if any, that detects, observes and/or creates a network, security, or application event or metric. Message queues and ETL components used in processing events or metrics are not considered observers in ECS.
        /// </summary>
        [DataMember(Name = "observer")]
        public Observer Observer { get; set; }

        /// <summary>
        /// The organization fields enrich data with information about the company or entity the data is associated with.<para/>These fields help you arrange or filter data stored in an index by one or multiple organizations.
        /// </summary>
        [DataMember(Name = "organization")]
        public Organization Organization { get; set; }

        /// <summary>
        /// The OS fields contain information about the operating system.
        /// </summary>
        [DataMember(Name = "os")]
        public Os Os { get; set; }

        /// <summary>
        /// These fields contain information about a process.<para/>These fields can help you correlate metrics information with a process id/name from a log message.  The `process.pid` often stays in the metric itself and is copied to the global field for correlation.
        /// </summary>
        [DataMember(Name = "process")]
        public Process Process { get; set; }

        /// <summary>
        /// This field set is meant to facilitate pivoting around a piece of data.<para/>Some pieces of information can be seen in many places in an ECS event. To facilitate searching for them, store an array of all seen values to their corresponding field in `related.`.<para/>A concrete example is IP addresses, which can be under host, observer, source, destination, client, server, and network.forwarded_ip. If you append all IPs to `related.ip`, you can then search for a given IP trivially, no matter where it appeared, by querying `related.ip:a.b.c.d`.
        /// </summary>
        [DataMember(Name = "related")]
        public Related Related { get; set; }

        /// <summary>
        /// A Server is defined as the responder in a network connection for events regarding sessions, connections, or bidirectional flow records.<para/>For TCP events, the server is the receiver of the initial SYN packet(s) of the TCP connection. For other protocols, the server is generally the responder in the network transaction. Some systems actually use the term "responder" to refer the server in TCP connections. The server fields describe details about the system acting as the server in the network event. Server fields are usually populated in conjunction with client fields. Server fields are generally not populated for packet-level events.<para/>Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
        /// </summary>
        [DataMember(Name = "server")]
        public Server Server { get; set; }

        /// <summary>
        /// The service fields describe the service for or from which the data was collected.<para/>These fields help you find and correlate logs for a specific service and version.
        /// </summary>
        [DataMember(Name = "service")]
        public Service Service { get; set; }

        /// <summary>
        /// Source fields describe details about the source of a packet/event.<para/>Source fields are usually populated in conjunction with destination fields.
        /// </summary>
        [DataMember(Name = "source")]
        public Source Source { get; set; }

        /// <summary>
        /// URL fields provide support for complete or partial URLs, and supports the breaking down into scheme, domain, path, and so on.
        /// </summary>
        [DataMember(Name = "url")]
        public Url Url { get; set; }

        /// <summary>
        /// The user fields describe information about the user that is relevant to the event.<para/>Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
        /// </summary>
        [DataMember(Name = "user")]
        public User User { get; set; }

        /// <summary>
        /// The user_agent fields normally come from a browser request.<para/>They often show up in web service logs coming from the parsed user agent string.
        /// </summary>
        [DataMember(Name = "user_agent")]
        public UserAgent UserAgent { get; set; }

        /// <summary>
        /// Date/time when the event originated.<para/>This is the date/time extracted from the event, typically representing when the event was generated by the source.<para/>If the event source has no original timestamp, this value is typically populated by the first time the event was received by the pipeline.<para/>Required field for all events.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>2016-05-23T08:05:34.853Z</example>
        [DataMember(Name = "@timestamp")]
        public DateTimeOffset? Timestamp { get; set; }

        /// <summary>
        /// List of keywords used to tag each event.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>[\"production\", \"env2\"]</example>
        [DataMember(Name = "tags")]
        public string Tags { get; set; }

        /// <summary>
        /// Custom key/value pairs.<para/>Can be used to add meta information to events. Should not contain nested objects. All values are stored as keyword.<para/>Example: `docker` and `k8s` labels.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>{"application":"foo-bar","env":"production"}</example>
        [DataMember(Name = "labels")]
        public object Labels { get; set; }

        /// <summary>
        /// For log events the message field contains the log message, optimized for viewing in a log viewer.<para/>For structured logs without an original message field, other fields can be concatenated to form a human-readable summary of the event.<para/>If multiple messages exist, they can be combined into one message.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Hello World</example>
        [DataMember(Name = "message")]
        public string Message { get; set; }

    }

    /// <summary>
    /// The agent fields contain the data about the software entity, if any, that collects, detects, or observes events on a host, or takes measurements on a host.<para/>Examples include Beats. Agents may also run on observers. ECS agent.* fields shall be populated with details of the agent running on the host or observer where the event happened or the measurement was taken.
    /// </summary>
    /// <remarks>
    /// Examples: In the case of Beats for logs, the agent.name is filebeat. For APM, it is the agent running in the app/service. The agent information does not change if data is sent through queuing systems like Kafka, Redis, or processing systems such as Logstash or APM Server.
    /// </remarks>
    public class Agent 
    {
        /// <summary>
        /// Version of the agent.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>6.0.0-rc2</example>
        [DataMember(Name = "version")]
        public string Version { get; set; }

        /// <summary>
        /// Custom name of the agent.<para/>This is a name that can be given to an agent. This can be helpful if for example two Filebeat instances are running on the same host but a human readable separation is needed on which Filebeat instance data is coming from.<para/>If no name is given, the name is often left empty.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>foo</example>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Type of the agent.<para/>The agent type stays always the same and should be given by the agent used. In case of Filebeat the agent would always be Filebeat also if two Filebeat instances are run on the same machine.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>filebeat</example>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Unique identifier of this agent (if one exists).<para/>Example: For Beats this would be beat.id.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>8a4f500d</example>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Ephemeral identifier of this agent (if one exists).<para/>This id normally changes across restarts, but `agent.id` does not.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>8a4f500f</example>
        [DataMember(Name = "ephemeral_id")]
        public string EphemeralId { get; set; }

    }

    /// <summary>
    /// A client is defined as the initiator of a network connection for events regarding sessions, connections, or bidirectional flow records.<para/>For TCP events, the client is the initiator of the TCP connection that sends the SYN packet(s). For other protocols, the client is generally the initiator or requestor in the network transaction. Some systems use the term "originator" to refer the client in TCP connections. The client fields describe details about the system acting as the client in the network event. Client fields are usually populated in conjunction with server fields. Client fields are generally not populated for packet-level events.<para/>Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
    /// </summary>
    public class Client 
    {
        /// <summary>
        /// Some event client addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field.<para/>Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Longitude and latitude.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "geo.location")]
        public GeoPoint GeoLocation { get; set; }

        /// <summary>
        /// Unique identifier for the group on the system/platform.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.group.id")]
        public string UserGroupId { get; set; }

        /// <summary>
        /// One or multiple unique identifiers of the user.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "user.id")]
        public string UserId { get; set; }

        /// <summary>
        /// Name of the continent.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>North America</example>
        [DataMember(Name = "geo.continent_name")]
        public string GeoContinentName { get; set; }

        /// <summary>
        /// IP address of the client.<para/>Can be one or multiple IPv4 or IPv6 addresses.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "ip")]
        public IPAddress Ip { get; set; }

        /// <summary>
        /// Name of the group.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.group.name")]
        public string UserGroupName { get; set; }

        /// <summary>
        /// Short name or login of the user.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>albert</example>
        [DataMember(Name = "user.name")]
        public string UserName { get; set; }

        /// <summary>
        /// Country name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Canada</example>
        [DataMember(Name = "geo.country_name")]
        public string GeoCountryName { get; set; }

        /// <summary>
        /// Port of the client.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "port")]
        public long? Port { get; set; }

        /// <summary>
        /// User's full name, if available.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Albert Einstein</example>
        [DataMember(Name = "user.full_name")]
        public string UserFullName { get; set; }

        /// <summary>
        /// Region name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Quebec</example>
        [DataMember(Name = "geo.region_name")]
        public string GeoRegionName { get; set; }

        /// <summary>
        /// MAC address of the client.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "mac")]
        public string Mac { get; set; }

        /// <summary>
        /// User email address.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.email")]
        public string UserEmail { get; set; }

        /// <summary>
        /// Client domain.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "domain")]
        public string Domain { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Montreal</example>
        [DataMember(Name = "geo.city_name")]
        public string GeoCityName { get; set; }

        /// <summary>
        /// Unique user hash to correlate information for a user in anonymized form.<para/>Useful if `user.id` or `user.name` contain confidential information and cannot be used.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.hash")]
        public string UserHash { get; set; }

        /// <summary>
        /// Bytes sent from the client to the server.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>184</example>
        [DataMember(Name = "bytes")]
        public long? Bytes { get; set; }

        /// <summary>
        /// Country ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA</example>
        [DataMember(Name = "geo.country_iso_code")]
        public string GeoCountryIsoCode { get; set; }

        /// <summary>
        /// Region ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA-QC</example>
        [DataMember(Name = "geo.region_iso_code")]
        public string GeoRegionIsoCode { get; set; }

        /// <summary>
        /// Packets sent from the client to the server.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>12</example>
        [DataMember(Name = "packets")]
        public long? Packets { get; set; }

        /// <summary>
        /// User-defined description of a location, at the level of granularity they care about.<para/>Could be the name of their data centers, the floor number, if this describes a local physical entity, city names.<para/>Not typically used in automated geolocation.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>boston-dc</example>
        [DataMember(Name = "geo.name")]
        public string GeoName { get; set; }

    }

    /// <summary>
    /// Fields related to the cloud or infrastructure the events are coming from.
    /// </summary>
    /// <remarks>
    /// Examples: If Metricbeat is running on an EC2 host and fetches data from its host, the cloud info contains the data about this machine. If Metricbeat runs on a remote machine outside the cloud and fetches data from a service running in the cloud, the field contains cloud data from the machine the service is running on.
    /// </remarks>
    public class Cloud 
    {
        /// <summary>
        /// Name of the cloud provider. Example values are aws, azure, gcp, or digitalocean.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>aws</example>
        [DataMember(Name = "provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Availability zone in which this host is running.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>us-east-1c</example>
        [DataMember(Name = "availability_zone")]
        public string AvailabilityZone { get; set; }

        /// <summary>
        /// Region in which this host is running.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>us-east-1</example>
        [DataMember(Name = "region")]
        public string Region { get; set; }

        /// <summary>
        /// Instance ID of the host machine.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>i-1234567890abcdef0</example>
        [DataMember(Name = "instance.id")]
        public string InstanceId { get; set; }

        /// <summary>
        /// Instance name of the host machine.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "instance.name")]
        public string InstanceName { get; set; }

        /// <summary>
        /// Machine type of the host machine.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>t2.medium</example>
        [DataMember(Name = "machine.type")]
        public string MachineType { get; set; }

        /// <summary>
        /// The cloud account or organization id used to identify different entities in a multi-tenant environment.<para/>Examples: AWS account id, Google Cloud ORG Id, or other unique identifier.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>666777888999</example>
        [DataMember(Name = "account.id")]
        public string AccountId { get; set; }

    }

    /// <summary>
    /// Container fields are used for meta information about the specific container that is the source of information.<para/>These fields help correlate data based containers from any runtime.
    /// </summary>
    public class Container 
    {
        /// <summary>
        /// Runtime managing this container.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>docker</example>
        [DataMember(Name = "runtime")]
        public string Runtime { get; set; }

        /// <summary>
        /// Unique container id.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the image the container was built on.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "image.name")]
        public string ImageName { get; set; }

        /// <summary>
        /// Container image tag.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "image.tag")]
        public string ImageTag { get; set; }

        /// <summary>
        /// Container name.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Image labels.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "labels")]
        public object Labels { get; set; }

    }

    /// <summary>
    /// Destination fields describe details about the destination of a packet/event.<para/>Destination fields are usually populated in conjunction with source fields.
    /// </summary>
    public class Destination 
    {
        /// <summary>
        /// Some event destination addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field.<para/>Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Longitude and latitude.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "geo.location")]
        public GeoPoint GeoLocation { get; set; }

        /// <summary>
        /// Unique identifier for the group on the system/platform.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.group.id")]
        public string UserGroupId { get; set; }

        /// <summary>
        /// One or multiple unique identifiers of the user.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "user.id")]
        public string UserId { get; set; }

        /// <summary>
        /// Name of the continent.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>North America</example>
        [DataMember(Name = "geo.continent_name")]
        public string GeoContinentName { get; set; }

        /// <summary>
        /// IP address of the destination.<para/>Can be one or multiple IPv4 or IPv6 addresses.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "ip")]
        public IPAddress Ip { get; set; }

        /// <summary>
        /// Name of the group.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.group.name")]
        public string UserGroupName { get; set; }

        /// <summary>
        /// Short name or login of the user.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>albert</example>
        [DataMember(Name = "user.name")]
        public string UserName { get; set; }

        /// <summary>
        /// Country name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Canada</example>
        [DataMember(Name = "geo.country_name")]
        public string GeoCountryName { get; set; }

        /// <summary>
        /// Port of the destination.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "port")]
        public long? Port { get; set; }

        /// <summary>
        /// User's full name, if available.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Albert Einstein</example>
        [DataMember(Name = "user.full_name")]
        public string UserFullName { get; set; }

        /// <summary>
        /// Region name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Quebec</example>
        [DataMember(Name = "geo.region_name")]
        public string GeoRegionName { get; set; }

        /// <summary>
        /// MAC address of the destination.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "mac")]
        public string Mac { get; set; }

        /// <summary>
        /// User email address.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.email")]
        public string UserEmail { get; set; }

        /// <summary>
        /// Destination domain.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "domain")]
        public string Domain { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Montreal</example>
        [DataMember(Name = "geo.city_name")]
        public string GeoCityName { get; set; }

        /// <summary>
        /// Unique user hash to correlate information for a user in anonymized form.<para/>Useful if `user.id` or `user.name` contain confidential information and cannot be used.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.hash")]
        public string UserHash { get; set; }

        /// <summary>
        /// Bytes sent from the destination to the source.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>184</example>
        [DataMember(Name = "bytes")]
        public long? Bytes { get; set; }

        /// <summary>
        /// Country ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA</example>
        [DataMember(Name = "geo.country_iso_code")]
        public string GeoCountryIsoCode { get; set; }

        /// <summary>
        /// Region ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA-QC</example>
        [DataMember(Name = "geo.region_iso_code")]
        public string GeoRegionIsoCode { get; set; }

        /// <summary>
        /// Packets sent from the destination to the source.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>12</example>
        [DataMember(Name = "packets")]
        public long? Packets { get; set; }

        /// <summary>
        /// User-defined description of a location, at the level of granularity they care about.<para/>Could be the name of their data centers, the floor number, if this describes a local physical entity, city names.<para/>Not typically used in automated geolocation.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>boston-dc</example>
        [DataMember(Name = "geo.name")]
        public string GeoName { get; set; }

    }

    /// <summary>
    /// Meta-information specific to ECS.
    /// </summary>
    public class Ecs 
    {
        /// <summary>
        /// ECS version this event conforms to. `ecs.version` is a required field and must exist in all events.<para/>When querying across multiple indices -- which may conform to slightly different ECS versions -- this field lets integrations adjust to the schema version of the events.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>1.0.0</example>
        [DataMember(Name = "version")]
        public string Version { get; set; }

    }

    /// <summary>
    /// These fields can represent errors of any kind.<para/>Use them for errors that happen while fetching events or in cases where the event itself contains an error.
    /// </summary>
    public class Error 
    {
        /// <summary>
        /// Unique identifier for the error.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Error code describing the error.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "code")]
        public string Code { get; set; }

    }

    /// <summary>
    /// The event fields are used for context information about the log or metric event itself.<para/>A log is defined as an event containing details of something that happened. Log events must include the time at which the thing happened. Examples of log events include a process starting on a host, a network packet being sent from a source to a destination, or a network connection between a client and a server being initiated or closed. A metric is defined as an event containing one or more numerical or categorical measurements and the time at which the measurement was taken. Examples of metric events include memory pressure measured on a host, or vulnerabilities measured on a scanned host.
    /// </summary>
    public class Event 
    {
        /// <summary>
        /// Unique ID to describe the event.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>8a4f500d</example>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The kind of the event.<para/>This gives information about what type of information the event contains, without being specific to the contents of the event.  Examples are `event`, `state`, `alarm`. Warning: In future versions of ECS, we plan to provide a list of acceptable values for this field, please use with caution.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>state</example>
        [DataMember(Name = "kind")]
        public string Kind { get; set; }

        /// <summary>
        /// Event category.<para/>This contains high-level information about the contents of the event. It is more generic than `event.action`, in the sense that typically a category contains multiple actions. Warning: In future versions of ECS, we plan to provide a list of acceptable values for this field, please use with caution.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>user-management</example>
        [DataMember(Name = "category")]
        public string Category { get; set; }

        /// <summary>
        /// The action captured by the event.<para/>This describes the information in the event. It is more specific than `event.category`. Examples are `group-add`, `process-started`, `file-created`. The value is normally defined by the implementer.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>user-password-change</example>
        [DataMember(Name = "action")]
        public string Action { get; set; }

        /// <summary>
        /// The outcome of the event.<para/>If the event describes an action, this fields contains the outcome of that action. Examples outcomes are `success` and `failure`. Warning: In future versions of ECS, we plan to provide a list of acceptable values for this field, please use with caution.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>success</example>
        [DataMember(Name = "outcome")]
        public string Outcome { get; set; }

        /// <summary>
        /// Reserved for future usage.<para/>Please avoid using this field for user data.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Name of the module this data is coming from.<para/>This information is coming from the modules used in Beats or Logstash.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>mysql</example>
        [DataMember(Name = "module")]
        public string Module { get; set; }

        /// <summary>
        /// Name of the dataset.<para/>The concept of a `dataset` (fileset / metricset) is used in Beats as a subset of modules. It contains the information which is currently stored in metricset.name and metricset.module or fileset.name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>stats</example>
        [DataMember(Name = "dataset")]
        public string Dataset { get; set; }

        /// <summary>
        /// Severity describes the original severity of the event. What the different severity values mean can very different between use cases. It's up to the implementer to make sure severities are consistent across events.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>7</example>
        [DataMember(Name = "severity")]
        public long? Severity { get; set; }

        /// <summary>
        /// Raw text message of entire event. Used to demonstrate log integrity.<para/>This field is not indexed and doc_values are disabled. It cannot be searched, but it can be retrieved from `_source`.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Sep 19 08:26:10 host CEF:0&#124;Security&#124; threatmanager&#124;1.0&#124;100&#124; worm successfully stopped&#124;10&#124;src=10.0.0.1 dst=2.1.2.2spt=1232</example>
        [DataMember(Name = "original")]
        public string Original { get; set; }

        /// <summary>
        /// Hash (perhaps logstash fingerprint) of raw field to be able to demonstrate log integrity.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>123456789012345678901234567890ABCD</example>
        [DataMember(Name = "hash")]
        public string Hash { get; set; }

        /// <summary>
        /// Duration of the event in nanoseconds.<para/>If event.start and event.end are known this value should be the difference between the end and start time.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "duration")]
        public long? Duration { get; set; }

        /// <summary>
        /// This field should be populated when the event's timestamp does not include timezone information already (e.g. default Syslog timestamps). It's optional otherwise.<para/>Acceptable timezone formats are: a canonical ID (e.g. "Europe/Amsterdam"), abbreviated (e.g. "EST") or an HH:mm differential (e.g. "-05:00").
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// event.created contains the date/time when the event was first read by an agent, or by your pipeline.<para/>This field is distinct from @timestamp in that @timestamp typically contain the time extracted from the original event.<para/>In most situations, these two timestamps will be slightly different. The difference can be used to calculate the delay between your source generating an event, and the time when your agent first processed it. This can be used to monitor your agent's or pipeline's ability to keep up with your event source.<para/>In case the two timestamps are identical, @timestamp should be used.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "created")]
        public DateTimeOffset? Created { get; set; }

        /// <summary>
        /// event.start contains the date when the event started or when the activity was first observed.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "start")]
        public DateTimeOffset? Start { get; set; }

        /// <summary>
        /// event.end contains the date when the event ended or when the activity was last observed.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "end")]
        public DateTimeOffset? End { get; set; }

        /// <summary>
        /// Risk score or priority of the event (e.g. security solutions). Use your system's original value here.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "risk_score")]
        public float? RiskScore { get; set; }

        /// <summary>
        /// Normalized risk score or priority of the event, on a scale of 0 to 100.<para/>This is mainly useful if you use more than one system that assigns risk scores, and you want to see a normalized value across all systems.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "risk_score_norm")]
        public float? RiskScoreNorm { get; set; }

    }

    /// <summary>
    /// A file is defined as a set of information that has been created on, or has existed on a filesystem.<para/>File objects can be associated with host events, network events, and/or file events (e.g., those produced by File Integrity Monitoring [FIM] products or services). File fields provide details about the affected file associated with the event or metric.
    /// </summary>
    public class File 
    {
        /// <summary>
        /// Path to the file.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "path")]
        public string Path { get; set; }

        /// <summary>
        /// Target path for symlinks.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "target_path")]
        public string TargetPath { get; set; }

        /// <summary>
        /// File extension.<para/>This should allow easy filtering by file extensions.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>png</example>
        [DataMember(Name = "extension")]
        public string Extension { get; set; }

        /// <summary>
        /// File type (file, dir, or symlink).
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Device that is the source of the file.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "device")]
        public string Device { get; set; }

        /// <summary>
        /// Inode representing the file in the filesystem.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "inode")]
        public string Inode { get; set; }

        /// <summary>
        /// The user ID (UID) or security identifier (SID) of the file owner.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "uid")]
        public string Uid { get; set; }

        /// <summary>
        /// File owner's username.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "owner")]
        public string Owner { get; set; }

        /// <summary>
        /// Primary group ID (GID) of the file.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "gid")]
        public string Gid { get; set; }

        /// <summary>
        /// Primary group name of the file.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "group")]
        public string Group { get; set; }

        /// <summary>
        /// Mode of the file in octal representation.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>416</example>
        [DataMember(Name = "mode")]
        public string Mode { get; set; }

        /// <summary>
        /// File size in bytes (field is only added when `type` is `file`).
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "size")]
        public long? Size { get; set; }

        /// <summary>
        /// Last time file content was modified.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "mtime")]
        public DateTimeOffset? Mtime { get; set; }

        /// <summary>
        /// Last time file metadata changed.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "ctime")]
        public DateTimeOffset? Ctime { get; set; }

    }

    /// <summary>
    /// Geo fields can carry data about a specific location related to an event.<para/>This geolocation information can be derived from techniques such as Geo IP, or be user-supplied.
    /// </summary>
    public class Geo 
    {
        /// <summary>
        /// Longitude and latitude.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "location")]
        public GeoPoint Location { get; set; }

        /// <summary>
        /// Name of the continent.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>North America</example>
        [DataMember(Name = "continent_name")]
        public string ContinentName { get; set; }

        /// <summary>
        /// Country name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Canada</example>
        [DataMember(Name = "country_name")]
        public string CountryName { get; set; }

        /// <summary>
        /// Region name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Quebec</example>
        [DataMember(Name = "region_name")]
        public string RegionName { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Montreal</example>
        [DataMember(Name = "city_name")]
        public string CityName { get; set; }

        /// <summary>
        /// Country ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA</example>
        [DataMember(Name = "country_iso_code")]
        public string CountryIsoCode { get; set; }

        /// <summary>
        /// Region ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA-QC</example>
        [DataMember(Name = "region_iso_code")]
        public string RegionIsoCode { get; set; }

        /// <summary>
        /// User-defined description of a location, at the level of granularity they care about.<para/>Could be the name of their data centers, the floor number, if this describes a local physical entity, city names.<para/>Not typically used in automated geolocation.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>boston-dc</example>
        [DataMember(Name = "name")]
        public string Name { get; set; }

    }

    /// <summary>
    /// The group fields are meant to represent groups that are relevant to the event.
    /// </summary>
    public class Group 
    {
        /// <summary>
        /// Unique identifier for the group on the system/platform.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the group.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "name")]
        public string Name { get; set; }

    }

    /// <summary>
    /// A host is defined as a general computing instance.<para/>ECS host.* fields should be populated with details about the host on which the event happened, or from which the measurement was taken. Host types include hardware, virtual machines, Docker containers, and Kubernetes nodes.
    /// </summary>
    public class Host 
    {
        /// <summary>
        /// Longitude and latitude.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "geo.location")]
        public GeoPoint GeoLocation { get; set; }

        /// <summary>
        /// Hostname of the host.<para/>It normally contains what the `hostname` command returns on the host machine.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// Operating system platform (such centos, ubuntu, windows).
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>darwin</example>
        [DataMember(Name = "os.platform")]
        public string OsPlatform { get; set; }

        /// <summary>
        /// Unique identifier for the group on the system/platform.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.group.id")]
        public string UserGroupId { get; set; }

        /// <summary>
        /// One or multiple unique identifiers of the user.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "user.id")]
        public string UserId { get; set; }

        /// <summary>
        /// Name of the continent.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>North America</example>
        [DataMember(Name = "geo.continent_name")]
        public string GeoContinentName { get; set; }

        /// <summary>
        /// Name of the host.<para/>It can contain what `hostname` returns on Unix systems, the fully qualified domain name, or a name specified by the user. The sender decides which value to use.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Operating system name, without the version.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Mac OS X</example>
        [DataMember(Name = "os.name")]
        public string OsName { get; set; }

        /// <summary>
        /// Name of the group.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.group.name")]
        public string UserGroupName { get; set; }

        /// <summary>
        /// Short name or login of the user.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>albert</example>
        [DataMember(Name = "user.name")]
        public string UserName { get; set; }

        /// <summary>
        /// Country name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Canada</example>
        [DataMember(Name = "geo.country_name")]
        public string GeoCountryName { get; set; }

        /// <summary>
        /// Unique host id.<para/>As hostname is not always unique, use values that are meaningful in your environment.<para/>Example: The current usage of `beat.name`.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Operating system name, including the version or code name.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Mac OS Mojave</example>
        [DataMember(Name = "os.full")]
        public string OsFull { get; set; }

        /// <summary>
        /// User's full name, if available.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Albert Einstein</example>
        [DataMember(Name = "user.full_name")]
        public string UserFullName { get; set; }

        /// <summary>
        /// Region name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Quebec</example>
        [DataMember(Name = "geo.region_name")]
        public string GeoRegionName { get; set; }

        /// <summary>
        /// Host ip address.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "ip")]
        public IPAddress Ip { get; set; }

        /// <summary>
        /// OS family (such as redhat, debian, freebsd, windows).
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>debian</example>
        [DataMember(Name = "os.family")]
        public string OsFamily { get; set; }

        /// <summary>
        /// User email address.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.email")]
        public string UserEmail { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Montreal</example>
        [DataMember(Name = "geo.city_name")]
        public string GeoCityName { get; set; }

        /// <summary>
        /// Host mac address.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "mac")]
        public string Mac { get; set; }

        /// <summary>
        /// Operating system version as a raw string.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>10.14.1</example>
        [DataMember(Name = "os.version")]
        public string OsVersion { get; set; }

        /// <summary>
        /// Unique user hash to correlate information for a user in anonymized form.<para/>Useful if `user.id` or `user.name` contain confidential information and cannot be used.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.hash")]
        public string UserHash { get; set; }

        /// <summary>
        /// Country ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA</example>
        [DataMember(Name = "geo.country_iso_code")]
        public string GeoCountryIsoCode { get; set; }

        /// <summary>
        /// Operating system kernel version as a raw string.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>4.4.0-112-generic</example>
        [DataMember(Name = "os.kernel")]
        public string OsKernel { get; set; }

        /// <summary>
        /// Type of host.<para/>For Cloud providers this can be the machine type like `t2.medium`. If vm, this could be the container, for example, or other information meaningful in your environment.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Operating system architecture.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>x86_64</example>
        [DataMember(Name = "architecture")]
        public string Architecture { get; set; }

        /// <summary>
        /// Region ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA-QC</example>
        [DataMember(Name = "geo.region_iso_code")]
        public string GeoRegionIsoCode { get; set; }

        /// <summary>
        /// User-defined description of a location, at the level of granularity they care about.<para/>Could be the name of their data centers, the floor number, if this describes a local physical entity, city names.<para/>Not typically used in automated geolocation.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>boston-dc</example>
        [DataMember(Name = "geo.name")]
        public string GeoName { get; set; }

    }

    /// <summary>
    /// Fields related to HTTP activity. Use the `url` field set to store the url of the request.
    /// </summary>
    public class Http 
    {
        /// <summary>
        /// HTTP request method.<para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>get, post, put</example>
        [DataMember(Name = "request.method")]
        public string RequestMethod { get; set; }

        /// <summary>
        /// The full HTTP request body.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Hello world</example>
        [DataMember(Name = "request.body.content")]
        public string RequestBodyContent { get; set; }

        /// <summary>
        /// Referrer for this HTTP request.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>https://blog.example.com/</example>
        [DataMember(Name = "request.referrer")]
        public string RequestReferrer { get; set; }

        /// <summary>
        /// HTTP response status code.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>404</example>
        [DataMember(Name = "response.status_code")]
        public long? ResponseStatusCode { get; set; }

        /// <summary>
        /// The full HTTP response body.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Hello world</example>
        [DataMember(Name = "response.body.content")]
        public string ResponseBodyContent { get; set; }

        /// <summary>
        /// HTTP version.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>1.1</example>
        [DataMember(Name = "version")]
        public string Version { get; set; }

        /// <summary>
        /// Total size in bytes of the request (body and headers).
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>1437</example>
        [DataMember(Name = "request.bytes")]
        public long? RequestBytes { get; set; }

        /// <summary>
        /// Size in bytes of the request body.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>887</example>
        [DataMember(Name = "request.body.bytes")]
        public long? RequestBodyBytes { get; set; }

        /// <summary>
        /// Total size in bytes of the response (body and headers).
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>1437</example>
        [DataMember(Name = "response.bytes")]
        public long? ResponseBytes { get; set; }

        /// <summary>
        /// Size in bytes of the response body.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>887</example>
        [DataMember(Name = "response.body.bytes")]
        public long? ResponseBodyBytes { get; set; }

    }

    /// <summary>
    /// Fields which are specific to log events.
    /// </summary>
    public class Log 
    {
        /// <summary>
        /// Original log level of the log event.<para/>Some examples are `warn`, `error`, `i`.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>err</example>
        [DataMember(Name = "level")]
        public string Level { get; set; }

        /// <summary>
        /// This is the original log message and contains the full log message before splitting it up in multiple parts.<para/>In contrast to the `message` field which can contain an extracted part of the log message, this field contains the original, full log message. It can have already some modifications applied like encoding or new lines removed to clean up the log message.<para/>This field is not indexed and doc_values are disabled so it can't be queried but the value can be retrieved from `_source`.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Sep 19 08:26:10 localhost My log</example>
        [DataMember(Name = "original")]
        public string Original { get; set; }

    }

    /// <summary>
    /// The network is defined as the communication path over which a host or network event happens.<para/>The network.* fields should be populated with details about the network activity associated with an event.
    /// </summary>
    public class Network 
    {
        /// <summary>
        /// Name given by operators to sections of their network.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Guest Wifi</example>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// In the OSI Model this would be the Network Layer. ipv4, ipv6, ipsec, pim, etc<para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>ipv4</example>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// IANA Protocol Number (https://www.iana.org/assignments/protocol-numbers/protocol-numbers.xhtml). Standardized list of protocols. This aligns well with NetFlow and sFlow related logs which use the IANA Protocol Number.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>6</example>
        [DataMember(Name = "iana_number")]
        public string IanaNumber { get; set; }

        /// <summary>
        /// Same as network.iana_number, but instead using the Keyword name of the transport layer (udp, tcp, ipv6-icmp, etc.)<para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>tcp</example>
        [DataMember(Name = "transport")]
        public string Transport { get; set; }

        /// <summary>
        /// A name given to an application level protocol. This can be arbitrarily assigned for things like microservices, but also apply to things like skype, icq, facebook, twitter. This would be used in situations where the vendor or service can be decoded such as from the source/dest IP owners, ports, or wire format.<para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>aim</example>
        [DataMember(Name = "application")]
        public string Application { get; set; }

        /// <summary>
        /// L7 Network protocol name. ex. http, lumberjack, transport protocol.<para/>The field value must be normalized to lowercase for querying. See the documentation section "Implementing ECS".
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>http</example>
        [DataMember(Name = "protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// Direction of the network traffic.<para/>Recommended values are:<para/>  * inbound<para/>  * outbound<para/>  * internal<para/>  * external<para/>  * unknown<para/><para/>When mapping events from a host-based monitoring context, populate this field from the host's point of view.<para/>When mapping events from a network or perimeter-based monitoring context, populate this field from the point of view of your network perimeter.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>inbound</example>
        [DataMember(Name = "direction")]
        public string Direction { get; set; }

        /// <summary>
        /// Host IP address when the source IP address is the proxy.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>192.1.1.2</example>
        [DataMember(Name = "forwarded_ip")]
        public IPAddress ForwardedIp { get; set; }

        /// <summary>
        /// A hash of source and destination IPs and ports, as well as the protocol used in a communication. This is a tool-agnostic standard to identify flows.<para/>Learn more at https://github.com/corelight/community-id-spec.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>1:hO+sN4H+MG5MY/8hIrXPqc4ZQz0=</example>
        [DataMember(Name = "community_id")]
        public string CommunityId { get; set; }

        /// <summary>
        /// Total bytes transferred in both directions.<para/>If `source.bytes` and `destination.bytes` are known, `network.bytes` is their sum.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>368</example>
        [DataMember(Name = "bytes")]
        public long? Bytes { get; set; }

        /// <summary>
        /// Total packets transferred in both directions.<para/>If `source.packets` and `destination.packets` are known, `network.packets` is their sum.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>24</example>
        [DataMember(Name = "packets")]
        public long? Packets { get; set; }

    }

    /// <summary>
    /// An observer is defined as a special network, security, or application device used to detect, observe, or create network, security, or application-related events and metrics.<para/>This could be a custom hardware appliance or a server that has been configured to run special network, security, or application software. Examples include firewalls, intrusion detection/prevention systems, network monitoring sensors, web application firewalls, data loss prevention systems, and APM servers. The observer.* fields shall be populated with details of the system, if any, that detects, observes and/or creates a network, security, or application event or metric. Message queues and ETL components used in processing events or metrics are not considered observers in ECS.
    /// </summary>
    public class Observer 
    {
        /// <summary>
        /// Longitude and latitude.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "geo.location")]
        public GeoPoint GeoLocation { get; set; }

        /// <summary>
        /// MAC address of the observer
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "mac")]
        public string Mac { get; set; }

        /// <summary>
        /// Operating system platform (such centos, ubuntu, windows).
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>darwin</example>
        [DataMember(Name = "os.platform")]
        public string OsPlatform { get; set; }

        /// <summary>
        /// Name of the continent.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>North America</example>
        [DataMember(Name = "geo.continent_name")]
        public string GeoContinentName { get; set; }

        /// <summary>
        /// IP address of the observer.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "ip")]
        public IPAddress Ip { get; set; }

        /// <summary>
        /// Operating system name, without the version.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Mac OS X</example>
        [DataMember(Name = "os.name")]
        public string OsName { get; set; }

        /// <summary>
        /// Country name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Canada</example>
        [DataMember(Name = "geo.country_name")]
        public string GeoCountryName { get; set; }

        /// <summary>
        /// Hostname of the observer.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// Operating system name, including the version or code name.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Mac OS Mojave</example>
        [DataMember(Name = "os.full")]
        public string OsFull { get; set; }

        /// <summary>
        /// Region name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Quebec</example>
        [DataMember(Name = "geo.region_name")]
        public string GeoRegionName { get; set; }

        /// <summary>
        /// OS family (such as redhat, debian, freebsd, windows).
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>debian</example>
        [DataMember(Name = "os.family")]
        public string OsFamily { get; set; }

        /// <summary>
        /// observer vendor information.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "vendor")]
        public string Vendor { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Montreal</example>
        [DataMember(Name = "geo.city_name")]
        public string GeoCityName { get; set; }

        /// <summary>
        /// Operating system version as a raw string.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>10.14.1</example>
        [DataMember(Name = "os.version")]
        public string OsVersion { get; set; }

        /// <summary>
        /// Observer version.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "version")]
        public string Version { get; set; }

        /// <summary>
        /// Country ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA</example>
        [DataMember(Name = "geo.country_iso_code")]
        public string GeoCountryIsoCode { get; set; }

        /// <summary>
        /// Operating system kernel version as a raw string.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>4.4.0-112-generic</example>
        [DataMember(Name = "os.kernel")]
        public string OsKernel { get; set; }

        /// <summary>
        /// Observer serial number.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "serial_number")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Region ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA-QC</example>
        [DataMember(Name = "geo.region_iso_code")]
        public string GeoRegionIsoCode { get; set; }

        /// <summary>
        /// The type of the observer the data is coming from.<para/>There is no predefined list of observer types. Some examples are `forwarder`, `firewall`, `ids`, `ips`, `proxy`, `poller`, `sensor`, `APM server`.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>firewall</example>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// User-defined description of a location, at the level of granularity they care about.<para/>Could be the name of their data centers, the floor number, if this describes a local physical entity, city names.<para/>Not typically used in automated geolocation.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>boston-dc</example>
        [DataMember(Name = "geo.name")]
        public string GeoName { get; set; }

    }

    /// <summary>
    /// The organization fields enrich data with information about the company or entity the data is associated with.<para/>These fields help you arrange or filter data stored in an index by one or multiple organizations.
    /// </summary>
    public class Organization 
    {
        /// <summary>
        /// Organization name.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Unique identifier for the organization.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "id")]
        public string Id { get; set; }

    }

    /// <summary>
    /// The OS fields contain information about the operating system.
    /// </summary>
    public class Os 
    {
        /// <summary>
        /// Operating system platform (such centos, ubuntu, windows).
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>darwin</example>
        [DataMember(Name = "platform")]
        public string Platform { get; set; }

        /// <summary>
        /// Operating system name, without the version.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Mac OS X</example>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Operating system name, including the version or code name.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Mac OS Mojave</example>
        [DataMember(Name = "full")]
        public string Full { get; set; }

        /// <summary>
        /// OS family (such as redhat, debian, freebsd, windows).
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>debian</example>
        [DataMember(Name = "family")]
        public string Family { get; set; }

        /// <summary>
        /// Operating system version as a raw string.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>10.14.1</example>
        [DataMember(Name = "version")]
        public string Version { get; set; }

        /// <summary>
        /// Operating system kernel version as a raw string.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>4.4.0-112-generic</example>
        [DataMember(Name = "kernel")]
        public string Kernel { get; set; }

    }

    /// <summary>
    /// These fields contain information about a process.<para/>These fields can help you correlate metrics information with a process id/name from a log message.  The `process.pid` often stays in the metric itself and is copied to the global field for correlation.
    /// </summary>
    public class Process 
    {
        /// <summary>
        /// Process id.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>4242</example>
        [DataMember(Name = "pid")]
        public long? Pid { get; set; }

        /// <summary>
        /// Process name.<para/>Sometimes called program name or similar.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>ssh</example>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Parent process' pid.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>4241</example>
        [DataMember(Name = "ppid")]
        public long? Ppid { get; set; }

        /// <summary>
        /// Array of process arguments.<para/>May be filtered to protect sensitive information.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>["ssh","-l","user","10.0.0.16"]</example>
        [DataMember(Name = "args")]
        public string[] Args { get; set; }

        /// <summary>
        /// Absolute path to the process executable.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>/usr/bin/ssh</example>
        [DataMember(Name = "executable")]
        public string Executable { get; set; }

        /// <summary>
        /// Process title.<para/>The proctitle, some times the same as process name. Can also be different: for example a browser setting its title to the web page currently opened.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Thread ID.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>4242</example>
        [DataMember(Name = "thread.id")]
        public long? ThreadId { get; set; }

        /// <summary>
        /// The time the process started.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>2016-05-23T08:05:34.853Z</example>
        [DataMember(Name = "start")]
        public DateTimeOffset? Start { get; set; }

        /// <summary>
        /// The working directory of the process.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>/home/alice</example>
        [DataMember(Name = "working_directory")]
        public string WorkingDirectory { get; set; }

    }

    /// <summary>
    /// This field set is meant to facilitate pivoting around a piece of data.<para/>Some pieces of information can be seen in many places in an ECS event. To facilitate searching for them, store an array of all seen values to their corresponding field in `related.`.<para/>A concrete example is IP addresses, which can be under host, observer, source, destination, client, server, and network.forwarded_ip. If you append all IPs to `related.ip`, you can then search for a given IP trivially, no matter where it appeared, by querying `related.ip:a.b.c.d`.
    /// </summary>
    public class Related 
    {
        /// <summary>
        /// All of the IPs seen on your event.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "ip")]
        public IPAddress Ip { get; set; }

    }

    /// <summary>
    /// A Server is defined as the responder in a network connection for events regarding sessions, connections, or bidirectional flow records.<para/>For TCP events, the server is the receiver of the initial SYN packet(s) of the TCP connection. For other protocols, the server is generally the responder in the network transaction. Some systems actually use the term "responder" to refer the server in TCP connections. The server fields describe details about the system acting as the server in the network event. Server fields are usually populated in conjunction with client fields. Server fields are generally not populated for packet-level events.<para/>Client / server representations can add semantic context to an exchange, which is helpful to visualize the data in certain situations. If your context falls in that category, you should still ensure that source and destination are filled appropriately.
    /// </summary>
    public class Server 
    {
        /// <summary>
        /// Some event server addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field.<para/>Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Longitude and latitude.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "geo.location")]
        public GeoPoint GeoLocation { get; set; }

        /// <summary>
        /// Unique identifier for the group on the system/platform.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.group.id")]
        public string UserGroupId { get; set; }

        /// <summary>
        /// One or multiple unique identifiers of the user.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "user.id")]
        public string UserId { get; set; }

        /// <summary>
        /// Name of the continent.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>North America</example>
        [DataMember(Name = "geo.continent_name")]
        public string GeoContinentName { get; set; }

        /// <summary>
        /// IP address of the server.<para/>Can be one or multiple IPv4 or IPv6 addresses.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "ip")]
        public IPAddress Ip { get; set; }

        /// <summary>
        /// Name of the group.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.group.name")]
        public string UserGroupName { get; set; }

        /// <summary>
        /// Short name or login of the user.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>albert</example>
        [DataMember(Name = "user.name")]
        public string UserName { get; set; }

        /// <summary>
        /// Country name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Canada</example>
        [DataMember(Name = "geo.country_name")]
        public string GeoCountryName { get; set; }

        /// <summary>
        /// Port of the server.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "port")]
        public long? Port { get; set; }

        /// <summary>
        /// User's full name, if available.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Albert Einstein</example>
        [DataMember(Name = "user.full_name")]
        public string UserFullName { get; set; }

        /// <summary>
        /// Region name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Quebec</example>
        [DataMember(Name = "geo.region_name")]
        public string GeoRegionName { get; set; }

        /// <summary>
        /// MAC address of the server.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "mac")]
        public string Mac { get; set; }

        /// <summary>
        /// User email address.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.email")]
        public string UserEmail { get; set; }

        /// <summary>
        /// Server domain.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "domain")]
        public string Domain { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Montreal</example>
        [DataMember(Name = "geo.city_name")]
        public string GeoCityName { get; set; }

        /// <summary>
        /// Unique user hash to correlate information for a user in anonymized form.<para/>Useful if `user.id` or `user.name` contain confidential information and cannot be used.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.hash")]
        public string UserHash { get; set; }

        /// <summary>
        /// Bytes sent from the server to the client.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>184</example>
        [DataMember(Name = "bytes")]
        public long? Bytes { get; set; }

        /// <summary>
        /// Country ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA</example>
        [DataMember(Name = "geo.country_iso_code")]
        public string GeoCountryIsoCode { get; set; }

        /// <summary>
        /// Region ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA-QC</example>
        [DataMember(Name = "geo.region_iso_code")]
        public string GeoRegionIsoCode { get; set; }

        /// <summary>
        /// Packets sent from the server to the client.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>12</example>
        [DataMember(Name = "packets")]
        public long? Packets { get; set; }

        /// <summary>
        /// User-defined description of a location, at the level of granularity they care about.<para/>Could be the name of their data centers, the floor number, if this describes a local physical entity, city names.<para/>Not typically used in automated geolocation.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>boston-dc</example>
        [DataMember(Name = "geo.name")]
        public string GeoName { get; set; }

    }

    /// <summary>
    /// The service fields describe the service for or from which the data was collected.<para/>These fields help you find and correlate logs for a specific service and version.
    /// </summary>
    public class Service 
    {
        /// <summary>
        /// Unique identifier of the running service. If the service is comprised of many nodes, the `service.id` should be the same for all nodes.<para/>This id should uniquely identify the service. This makes it possible to correlate logs and metrics for one specific service, no matter which particular node emitted the event.<para/>Note that if you need to see the events from one specific host of the service, you should filter on that `host.name` or `host.id` instead.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>d37e5ebfe0ae6c4972dbe9f0174a1637bb8247f6</example>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the service data is collected from.<para/>The name of the service is normally user given. This allows if two instances of the same service are running on the same machine they can be differentiated by the `service.name`.<para/>Also it allows for distributed services that run on multiple hosts to correlate the related instances based on the name.<para/>In the case of Elasticsearch the service.name could contain the cluster name. For Beats the service.name is by default a copy of the `service.type` field if no name is specified.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>elasticsearch-metrics</example>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The type of the service data is collected from.<para/>The type can be used to group and correlate logs and metrics from one service type.<para/>Example: If logs or metrics are collected from Elasticsearch, `service.type` would be `elasticsearch`.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>elasticsearch</example>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Current state of the service.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "state")]
        public string State { get; set; }

        /// <summary>
        /// Version of the service the data was collected from.<para/>This allows to look at a data set only for a specific version of a service.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>3.2.4</example>
        [DataMember(Name = "version")]
        public string Version { get; set; }

        /// <summary>
        /// Ephemeral identifier of this service (if one exists).<para/>This id normally changes across restarts, but `service.id` does not.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>8a4f500f</example>
        [DataMember(Name = "ephemeral_id")]
        public string EphemeralId { get; set; }

    }

    /// <summary>
    /// Source fields describe details about the source of a packet/event.<para/>Source fields are usually populated in conjunction with destination fields.
    /// </summary>
    public class Source 
    {
        /// <summary>
        /// Some event source addresses are defined ambiguously. The event will sometimes list an IP, a domain or a unix socket.  You should always store the raw address in the `.address` field.<para/>Then it should be duplicated to `.ip` or `.domain`, depending on which one it is.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Longitude and latitude.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>{ \"lon\": -73.614830, \"lat\": 45.505918 }</example>
        [DataMember(Name = "geo.location")]
        public GeoPoint GeoLocation { get; set; }

        /// <summary>
        /// Unique identifier for the group on the system/platform.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.group.id")]
        public string UserGroupId { get; set; }

        /// <summary>
        /// One or multiple unique identifiers of the user.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "user.id")]
        public string UserId { get; set; }

        /// <summary>
        /// Name of the continent.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>North America</example>
        [DataMember(Name = "geo.continent_name")]
        public string GeoContinentName { get; set; }

        /// <summary>
        /// IP address of the source.<para/>Can be one or multiple IPv4 or IPv6 addresses.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "ip")]
        public IPAddress Ip { get; set; }

        /// <summary>
        /// Name of the group.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.group.name")]
        public string UserGroupName { get; set; }

        /// <summary>
        /// Short name or login of the user.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>albert</example>
        [DataMember(Name = "user.name")]
        public string UserName { get; set; }

        /// <summary>
        /// Country name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Canada</example>
        [DataMember(Name = "geo.country_name")]
        public string GeoCountryName { get; set; }

        /// <summary>
        /// Port of the source.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "port")]
        public long? Port { get; set; }

        /// <summary>
        /// User's full name, if available.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Albert Einstein</example>
        [DataMember(Name = "user.full_name")]
        public string UserFullName { get; set; }

        /// <summary>
        /// Region name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Quebec</example>
        [DataMember(Name = "geo.region_name")]
        public string GeoRegionName { get; set; }

        /// <summary>
        /// MAC address of the source.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "mac")]
        public string Mac { get; set; }

        /// <summary>
        /// User email address.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.email")]
        public string UserEmail { get; set; }

        /// <summary>
        /// Source domain.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "domain")]
        public string Domain { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>Montreal</example>
        [DataMember(Name = "geo.city_name")]
        public string GeoCityName { get; set; }

        /// <summary>
        /// Unique user hash to correlate information for a user in anonymized form.<para/>Useful if `user.id` or `user.name` contain confidential information and cannot be used.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "user.hash")]
        public string UserHash { get; set; }

        /// <summary>
        /// Bytes sent from the source to the destination.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>184</example>
        [DataMember(Name = "bytes")]
        public long? Bytes { get; set; }

        /// <summary>
        /// Country ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA</example>
        [DataMember(Name = "geo.country_iso_code")]
        public string GeoCountryIsoCode { get; set; }

        /// <summary>
        /// Region ISO code.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>CA-QC</example>
        [DataMember(Name = "geo.region_iso_code")]
        public string GeoRegionIsoCode { get; set; }

        /// <summary>
        /// Packets sent from the source to the destination.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>12</example>
        [DataMember(Name = "packets")]
        public long? Packets { get; set; }

        /// <summary>
        /// User-defined description of a location, at the level of granularity they care about.<para/>Could be the name of their data centers, the floor number, if this describes a local physical entity, city names.<para/>Not typically used in automated geolocation.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>boston-dc</example>
        [DataMember(Name = "geo.name")]
        public string GeoName { get; set; }

    }

    /// <summary>
    /// URL fields provide support for complete or partial URLs, and supports the breaking down into scheme, domain, path, and so on.
    /// </summary>
    public class Url 
    {
        /// <summary>
        /// Unmodified original url as seen in the event source.<para/>Note that in network monitoring, the observed URL may be a full URL, whereas in access logs, the URL is often just represented as a path.<para/>This field is meant to represent the URL as it was observed, complete or not.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>https://www.elastic.co:443/search?q=elasticsearch#top or /search?q=elasticsearch</example>
        [DataMember(Name = "original")]
        public string Original { get; set; }

        /// <summary>
        /// If full URLs are important to your use case, they should be stored in `url.full`, whether this field is reconstructed or present in the event source.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>https://www.elastic.co:443/search?q=elasticsearch#top</example>
        [DataMember(Name = "full")]
        public string Full { get; set; }

        /// <summary>
        /// Scheme of the request, such as "https".<para/>Note: The `:` is not part of the scheme.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>https</example>
        [DataMember(Name = "scheme")]
        public string Scheme { get; set; }

        /// <summary>
        /// Domain of the url, such as "www.elastic.co".<para/>In some cases a URL may refer to an IP and/or port directly, without a domain name. In this case, the IP address would go to the `domain` field.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>www.elastic.co</example>
        [DataMember(Name = "domain")]
        public string Domain { get; set; }

        /// <summary>
        /// Port of the request, such as 443.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>443</example>
        [DataMember(Name = "port")]
        public long? Port { get; set; }

        /// <summary>
        /// Path of the request, such as "/search".
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "path")]
        public string Path { get; set; }

        /// <summary>
        /// The query field describes the query string of the request, such as "q=elasticsearch".<para/>The `?` is excluded from the query string. If a URL contains no `?`, there is no query field. If there is a `?` but no query, the query field exists with an empty string. The `exists` query can be used to differentiate between the two cases.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "query")]
        public string Query { get; set; }

        /// <summary>
        /// Portion of the url after the `#`, such as "top".<para/>The `#` is not part of the fragment.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "fragment")]
        public string Fragment { get; set; }

        /// <summary>
        /// Username of the request.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Password of the request.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "password")]
        public string Password { get; set; }

    }

    /// <summary>
    /// The user fields describe information about the user that is relevant to the event.<para/>Fields can have one entry or multiple entries. If a user has more than one id, provide an array that includes all of them.
    /// </summary>
    public class User 
    {
        /// <summary>
        /// Unique identifier for the group on the system/platform.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "group.id")]
        public string GroupId { get; set; }

        /// <summary>
        /// One or multiple unique identifiers of the user.
        /// </summary>
        /// <remarks>Core</remarks>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the group.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "group.name")]
        public string GroupName { get; set; }

        /// <summary>
        /// Short name or login of the user.
        /// </summary>
        /// <remarks>Core</remarks>
        /// <example>albert</example>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// User's full name, if available.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Albert Einstein</example>
        [DataMember(Name = "full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// User email address.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Unique user hash to correlate information for a user in anonymized form.<para/>Useful if `user.id` or `user.name` contain confidential information and cannot be used.
        /// </summary>
        /// <remarks>Extended</remarks>
        [DataMember(Name = "hash")]
        public string Hash { get; set; }

    }

    /// <summary>
    /// The user_agent fields normally come from a browser request.<para/>They often show up in web service logs coming from the parsed user agent string.
    /// </summary>
    public class UserAgent 
    {
        /// <summary>
        /// Unparsed version of the user_agent.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Mozilla/5.0 (iPhone; CPU iPhone OS 12_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/12.0 Mobile/15E148 Safari/604.1</example>
        [DataMember(Name = "original")]
        public string Original { get; set; }

        /// <summary>
        /// Operating system platform (such centos, ubuntu, windows).
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>darwin</example>
        [DataMember(Name = "os.platform")]
        public string OsPlatform { get; set; }

        /// <summary>
        /// Name of the user agent.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Safari</example>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Operating system name, without the version.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Mac OS X</example>
        [DataMember(Name = "os.name")]
        public string OsName { get; set; }

        /// <summary>
        /// Operating system name, including the version or code name.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>Mac OS Mojave</example>
        [DataMember(Name = "os.full")]
        public string OsFull { get; set; }

        /// <summary>
        /// Version of the user agent.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>12.0</example>
        [DataMember(Name = "version")]
        public string Version { get; set; }

        /// <summary>
        /// Name of the device.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>iPhone</example>
        [DataMember(Name = "device.name")]
        public string DeviceName { get; set; }

        /// <summary>
        /// OS family (such as redhat, debian, freebsd, windows).
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>debian</example>
        [DataMember(Name = "os.family")]
        public string OsFamily { get; set; }

        /// <summary>
        /// Operating system version as a raw string.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>10.14.1</example>
        [DataMember(Name = "os.version")]
        public string OsVersion { get; set; }

        /// <summary>
        /// Operating system kernel version as a raw string.
        /// </summary>
        /// <remarks>Extended</remarks>
        /// <example>4.4.0-112-generic</example>
        [DataMember(Name = "os.kernel")]
        public string OsKernel { get; set; }

    }

    /// <summary>
    /// Elastic Common Schema templates for version 1.0.
    /// <para/>
    /// These templates can be run against Elasticsearch to create index templates for ECS version 1.0.
    /// </summary>
    public class CommonSchemaTemplates
    {
        /// <summary>
        /// ECS Template for Elasticsearch 6
        /// </summary>
        public static string GetIndexTemplateForElasticsearch6() { return "{  \"index_patterns\": [    \"ecs-*\"  ],   \"mappings\": {    \"_doc\": {      \"_meta\": {        \"version\": \"1.0.1\"      },       \"date_detection\": false,       \"dynamic_templates\": [        {          \"strings_as_keyword\": {            \"mapping\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"match_mapping_type\": \"string\"          }        }      ],       \"properties\": {        \"@timestamp\": {          \"type\": \"date\"        },         \"agent\": {          \"properties\": {            \"ephemeral_id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"client\": {          \"properties\": {            \"address\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"bytes\": {              \"type\": \"long\"            },             \"domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"continent_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"location\": {                  \"type\": \"geo_point\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"ip\": {              \"type\": \"ip\"            },             \"mac\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"packets\": {              \"type\": \"long\"            },             \"port\": {              \"type\": \"long\"            },             \"user\": {              \"properties\": {                \"email\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"group\": {                  \"properties\": {                    \"id\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"hash\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            }          }        },         \"cloud\": {          \"properties\": {            \"account\": {              \"properties\": {                \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"availability_zone\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"instance\": {              \"properties\": {                \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"machine\": {              \"properties\": {                \"type\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"provider\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"region\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"container\": {          \"properties\": {            \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"image\": {              \"properties\": {                \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"tag\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"labels\": {              \"type\": \"object\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"runtime\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"destination\": {          \"properties\": {            \"address\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"bytes\": {              \"type\": \"long\"            },             \"domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"continent_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"location\": {                  \"type\": \"geo_point\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"ip\": {              \"type\": \"ip\"            },             \"mac\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"packets\": {              \"type\": \"long\"            },             \"port\": {              \"type\": \"long\"            },             \"user\": {              \"properties\": {                \"email\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"group\": {                  \"properties\": {                    \"id\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"hash\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            }          }        },         \"ecs\": {          \"properties\": {            \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"error\": {          \"properties\": {            \"code\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"message\": {              \"norms\": false,               \"type\": \"text\"            }          }        },         \"event\": {          \"properties\": {            \"action\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"category\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"created\": {              \"type\": \"date\"            },             \"dataset\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"duration\": {              \"type\": \"long\"            },             \"end\": {              \"type\": \"date\"            },             \"hash\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"kind\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"module\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"original\": {              \"doc_values\": false,               \"ignore_above\": 1024,               \"index\": false,               \"type\": \"keyword\"            },             \"outcome\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"risk_score\": {              \"type\": \"float\"            },             \"risk_score_norm\": {              \"type\": \"float\"            },             \"severity\": {              \"type\": \"long\"            },             \"start\": {              \"type\": \"date\"            },             \"timezone\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"file\": {          \"properties\": {            \"ctime\": {              \"type\": \"date\"            },             \"device\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"extension\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"gid\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"group\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"inode\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"mode\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"mtime\": {              \"type\": \"date\"            },             \"owner\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"path\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"size\": {              \"type\": \"long\"            },             \"target_path\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"uid\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"geo\": {          \"properties\": {            \"city_name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"continent_name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"country_iso_code\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"country_name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"location\": {              \"type\": \"geo_point\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"region_iso_code\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"region_name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"group\": {          \"properties\": {            \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"host\": {          \"properties\": {            \"architecture\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"continent_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"location\": {                  \"type\": \"geo_point\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"hostname\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"ip\": {              \"type\": \"ip\"            },             \"mac\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"os\": {              \"properties\": {                \"family\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"kernel\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"platform\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"version\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"user\": {              \"properties\": {                \"email\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"group\": {                  \"properties\": {                    \"id\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"hash\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            }          }        },         \"http\": {          \"properties\": {            \"request\": {              \"properties\": {                \"body\": {                  \"properties\": {                    \"bytes\": {                      \"type\": \"long\"                    },                     \"content\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"bytes\": {                  \"type\": \"long\"                },                 \"method\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"referrer\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"response\": {              \"properties\": {                \"body\": {                  \"properties\": {                    \"bytes\": {                      \"type\": \"long\"                    },                     \"content\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"bytes\": {                  \"type\": \"long\"                },                 \"status_code\": {                  \"type\": \"long\"                }              }            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"labels\": {          \"type\": \"object\"        },         \"log\": {          \"properties\": {            \"level\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"original\": {              \"doc_values\": false,               \"ignore_above\": 1024,               \"index\": false,               \"type\": \"keyword\"            }          }        },         \"message\": {          \"norms\": false,           \"type\": \"text\"        },         \"network\": {          \"properties\": {            \"application\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"bytes\": {              \"type\": \"long\"            },             \"community_id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"direction\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"forwarded_ip\": {              \"type\": \"ip\"            },             \"iana_number\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"packets\": {              \"type\": \"long\"            },             \"protocol\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"transport\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"observer\": {          \"properties\": {            \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"continent_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"location\": {                  \"type\": \"geo_point\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"hostname\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"ip\": {              \"type\": \"ip\"            },             \"mac\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"os\": {              \"properties\": {                \"family\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"kernel\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"platform\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"version\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"serial_number\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"vendor\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"organization\": {          \"properties\": {            \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"os\": {          \"properties\": {            \"family\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"full\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"kernel\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"platform\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"process\": {          \"properties\": {            \"args\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"executable\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"pid\": {              \"type\": \"long\"            },             \"ppid\": {              \"type\": \"long\"            },             \"start\": {              \"type\": \"date\"            },             \"thread\": {              \"properties\": {                \"id\": {                  \"type\": \"long\"                }              }            },             \"title\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"working_directory\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"related\": {          \"properties\": {            \"ip\": {              \"type\": \"ip\"            }          }        },         \"server\": {          \"properties\": {            \"address\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"bytes\": {              \"type\": \"long\"            },             \"domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"continent_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"location\": {                  \"type\": \"geo_point\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"ip\": {              \"type\": \"ip\"            },             \"mac\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"packets\": {              \"type\": \"long\"            },             \"port\": {              \"type\": \"long\"            },             \"user\": {              \"properties\": {                \"email\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"group\": {                  \"properties\": {                    \"id\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"hash\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            }          }        },         \"service\": {          \"properties\": {            \"ephemeral_id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"state\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"type\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"source\": {          \"properties\": {            \"address\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"bytes\": {              \"type\": \"long\"            },             \"domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"geo\": {              \"properties\": {                \"city_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"continent_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"country_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"location\": {                  \"type\": \"geo_point\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_iso_code\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"region_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"ip\": {              \"type\": \"ip\"            },             \"mac\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"packets\": {              \"type\": \"long\"            },             \"port\": {              \"type\": \"long\"            },             \"user\": {              \"properties\": {                \"email\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full_name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"group\": {                  \"properties\": {                    \"id\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    },                     \"name\": {                      \"ignore_above\": 1024,                       \"type\": \"keyword\"                    }                  }                },                 \"hash\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            }          }        },         \"tags\": {          \"ignore_above\": 1024,           \"type\": \"keyword\"        },         \"url\": {          \"properties\": {            \"domain\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"fragment\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"full\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"original\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"password\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"path\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"port\": {              \"type\": \"long\"            },             \"query\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"scheme\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"username\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"user\": {          \"properties\": {            \"email\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"full_name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"group\": {              \"properties\": {                \"id\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"hash\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"id\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        },         \"user_agent\": {          \"properties\": {            \"device\": {              \"properties\": {                \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"name\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"original\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            },             \"os\": {              \"properties\": {                \"family\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"full\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"kernel\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"name\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"platform\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                },                 \"version\": {                  \"ignore_above\": 1024,                   \"type\": \"keyword\"                }              }            },             \"version\": {              \"ignore_above\": 1024,               \"type\": \"keyword\"            }          }        }      }    }  },   \"order\": 1,   \"settings\": {    \"index\": {      \"mapping\": {        \"total_fields\": {          \"limit\": 10000        }      },       \"refresh_interval\": \"5s\"    }  }}"; }

        /// <summary>
        /// ECS Template for Elasticsearch 7
        /// </summary>
        public static string GetIndexTemplateForElasticsearch7() { return "{  \"index_patterns\": [    \"ecs-*\"  ],   \"mappings\": {    \"_meta\": {      \"version\": \"1.0.1\"    },     \"date_detection\": false,     \"dynamic_templates\": [      {        \"strings_as_keyword\": {          \"mapping\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"match_mapping_type\": \"string\"        }      }    ],     \"properties\": {      \"@timestamp\": {        \"type\": \"date\"      },       \"agent\": {        \"properties\": {          \"ephemeral_id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"client\": {        \"properties\": {          \"address\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"bytes\": {            \"type\": \"long\"          },           \"domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"continent_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"location\": {                \"type\": \"geo_point\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"ip\": {            \"type\": \"ip\"          },           \"mac\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"packets\": {            \"type\": \"long\"          },           \"port\": {            \"type\": \"long\"          },           \"user\": {            \"properties\": {              \"email\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"group\": {                \"properties\": {                  \"id\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"hash\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          }        }      },       \"cloud\": {        \"properties\": {          \"account\": {            \"properties\": {              \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"availability_zone\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"instance\": {            \"properties\": {              \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"machine\": {            \"properties\": {              \"type\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"provider\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"region\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"container\": {        \"properties\": {          \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"image\": {            \"properties\": {              \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"tag\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"labels\": {            \"type\": \"object\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"runtime\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"destination\": {        \"properties\": {          \"address\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"bytes\": {            \"type\": \"long\"          },           \"domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"continent_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"location\": {                \"type\": \"geo_point\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"ip\": {            \"type\": \"ip\"          },           \"mac\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"packets\": {            \"type\": \"long\"          },           \"port\": {            \"type\": \"long\"          },           \"user\": {            \"properties\": {              \"email\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"group\": {                \"properties\": {                  \"id\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"hash\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          }        }      },       \"ecs\": {        \"properties\": {          \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"error\": {        \"properties\": {          \"code\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"message\": {            \"norms\": false,             \"type\": \"text\"          }        }      },       \"event\": {        \"properties\": {          \"action\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"category\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"created\": {            \"type\": \"date\"          },           \"dataset\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"duration\": {            \"type\": \"long\"          },           \"end\": {            \"type\": \"date\"          },           \"hash\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"kind\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"module\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"original\": {            \"doc_values\": false,             \"ignore_above\": 1024,             \"index\": false,             \"type\": \"keyword\"          },           \"outcome\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"risk_score\": {            \"type\": \"float\"          },           \"risk_score_norm\": {            \"type\": \"float\"          },           \"severity\": {            \"type\": \"long\"          },           \"start\": {            \"type\": \"date\"          },           \"timezone\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"file\": {        \"properties\": {          \"ctime\": {            \"type\": \"date\"          },           \"device\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"extension\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"gid\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"group\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"inode\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"mode\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"mtime\": {            \"type\": \"date\"          },           \"owner\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"path\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"size\": {            \"type\": \"long\"          },           \"target_path\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"uid\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"geo\": {        \"properties\": {          \"city_name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"continent_name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"country_iso_code\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"country_name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"location\": {            \"type\": \"geo_point\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"region_iso_code\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"region_name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"group\": {        \"properties\": {          \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"host\": {        \"properties\": {          \"architecture\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"continent_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"location\": {                \"type\": \"geo_point\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"hostname\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"ip\": {            \"type\": \"ip\"          },           \"mac\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"os\": {            \"properties\": {              \"family\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"kernel\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"platform\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"version\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"user\": {            \"properties\": {              \"email\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"group\": {                \"properties\": {                  \"id\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"hash\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          }        }      },       \"http\": {        \"properties\": {          \"request\": {            \"properties\": {              \"body\": {                \"properties\": {                  \"bytes\": {                    \"type\": \"long\"                  },                   \"content\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"bytes\": {                \"type\": \"long\"              },               \"method\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"referrer\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"response\": {            \"properties\": {              \"body\": {                \"properties\": {                  \"bytes\": {                    \"type\": \"long\"                  },                   \"content\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"bytes\": {                \"type\": \"long\"              },               \"status_code\": {                \"type\": \"long\"              }            }          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"labels\": {        \"type\": \"object\"      },       \"log\": {        \"properties\": {          \"level\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"original\": {            \"doc_values\": false,             \"ignore_above\": 1024,             \"index\": false,             \"type\": \"keyword\"          }        }      },       \"message\": {        \"norms\": false,         \"type\": \"text\"      },       \"network\": {        \"properties\": {          \"application\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"bytes\": {            \"type\": \"long\"          },           \"community_id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"direction\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"forwarded_ip\": {            \"type\": \"ip\"          },           \"iana_number\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"packets\": {            \"type\": \"long\"          },           \"protocol\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"transport\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"observer\": {        \"properties\": {          \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"continent_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"location\": {                \"type\": \"geo_point\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"hostname\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"ip\": {            \"type\": \"ip\"          },           \"mac\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"os\": {            \"properties\": {              \"family\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"kernel\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"platform\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"version\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"serial_number\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"vendor\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"organization\": {        \"properties\": {          \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"os\": {        \"properties\": {          \"family\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"full\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"kernel\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"platform\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"process\": {        \"properties\": {          \"args\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"executable\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"pid\": {            \"type\": \"long\"          },           \"ppid\": {            \"type\": \"long\"          },           \"start\": {            \"type\": \"date\"          },           \"thread\": {            \"properties\": {              \"id\": {                \"type\": \"long\"              }            }          },           \"title\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"working_directory\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"related\": {        \"properties\": {          \"ip\": {            \"type\": \"ip\"          }        }      },       \"server\": {        \"properties\": {          \"address\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"bytes\": {            \"type\": \"long\"          },           \"domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"continent_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"location\": {                \"type\": \"geo_point\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"ip\": {            \"type\": \"ip\"          },           \"mac\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"packets\": {            \"type\": \"long\"          },           \"port\": {            \"type\": \"long\"          },           \"user\": {            \"properties\": {              \"email\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"group\": {                \"properties\": {                  \"id\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"hash\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          }        }      },       \"service\": {        \"properties\": {          \"ephemeral_id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"state\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"type\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"source\": {        \"properties\": {          \"address\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"bytes\": {            \"type\": \"long\"          },           \"domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"geo\": {            \"properties\": {              \"city_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"continent_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"country_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"location\": {                \"type\": \"geo_point\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_iso_code\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"region_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"ip\": {            \"type\": \"ip\"          },           \"mac\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"packets\": {            \"type\": \"long\"          },           \"port\": {            \"type\": \"long\"          },           \"user\": {            \"properties\": {              \"email\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full_name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"group\": {                \"properties\": {                  \"id\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  },                   \"name\": {                    \"ignore_above\": 1024,                     \"type\": \"keyword\"                  }                }              },               \"hash\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          }        }      },       \"tags\": {        \"ignore_above\": 1024,         \"type\": \"keyword\"      },       \"url\": {        \"properties\": {          \"domain\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"fragment\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"full\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"original\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"password\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"path\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"port\": {            \"type\": \"long\"          },           \"query\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"scheme\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"username\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"user\": {        \"properties\": {          \"email\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"full_name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"group\": {            \"properties\": {              \"id\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"hash\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"id\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      },       \"user_agent\": {        \"properties\": {          \"device\": {            \"properties\": {              \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"name\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"original\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          },           \"os\": {            \"properties\": {              \"family\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"full\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"kernel\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"name\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"platform\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              },               \"version\": {                \"ignore_above\": 1024,                 \"type\": \"keyword\"              }            }          },           \"version\": {            \"ignore_above\": 1024,             \"type\": \"keyword\"          }        }      }    }  },   \"order\": 1,   \"settings\": {    \"index\": {      \"mapping\": {        \"total_fields\": {          \"limit\": 10000        }      },       \"refresh_interval\": \"5s\"    }  }}"; }

    }
}