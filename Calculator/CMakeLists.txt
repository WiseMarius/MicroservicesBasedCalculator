# CMakeList.txt : CMake project for Calculator, include source and define
# project specific logic here.
#
cmake_minimum_required (VERSION 3.8)

# Paths
set(INCROOT ${CMAKE_CURRENT_SOURCE_DIR}/include)
set(SRCROOT ${CMAKE_CURRENT_SOURCE_DIR}/source)

# All source files
file(GLOB INCS "${INCROOT}/*.h")
file(GLOB SRCS "${SRCROOT}/*.cpp")

include_directories(${INCROOT})

# Add source to this project's executable.
add_executable (Calculator ${SRCS} ${INCS})

find_package(gRPC REQUIRED Protobuf REQUIRED)

target_link_libraries(Calculator gRPC::grpc++_reflection protobuf::libprotobuf)

# TODO: Add tests and install targets if needed.
