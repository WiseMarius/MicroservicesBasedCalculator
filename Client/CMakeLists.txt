# CMakeList.txt : CMake project for Client, include source and define
# project specific logic here.
#
cmake_minimum_required (VERSION 3.8)

# Paths
set(INCROOT ${CMAKE_CURRENT_SOURCE_DIR}/include)
set(SRCROOT ${CMAKE_CURRENT_SOURCE_DIR}/source)
set(PROTO   ${PROJECT_SOURCE_DIR}/Protos)

# All source files
file(GLOB INCS    "${INCROOT}/*.h")
file(GLOB SRCS    "${SRCROOT}/*.cpp")
file(GLOB PRTINCS "${PROTO}/*.h")
file(GLOB PRTSRCS "${PROTO}/*.cc")

include_directories(${INCROOT} ${PROTO})

# Add source to this project's executable.
add_executable (Client ${INCS} ${SRCS} ${PRTINCS} ${PRTSRCS})

find_package(gRPC REQUIRED Protobuf 3.9.1 REQUIRED)

target_link_libraries(Client gRPC::grpc++_reflection protobuf::libprotobuf)

# TODO: Add tests and install targets if needed.
